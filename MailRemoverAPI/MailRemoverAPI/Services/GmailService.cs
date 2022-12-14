﻿using MailRemoverAPI.Entities;
using MailRemoverAPI.Events;
using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Models.Gmail;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MailRemoverAPI.Services
{
    public class GmailService : IGmailService
    {
        private IConfiguration _configuration;
        private IGmailRepository _repository;
        private IHttpRequestService _httpRequestService;

        public GmailService(IConfiguration configuration, IGmailRepository repository, IHttpRequestService httpRequestService)
        {
            _configuration = configuration;
            _repository = repository;
            _httpRequestService = httpRequestService;
        }

        private async void AccessTokenExpiredHandler(Gmail source, AccessTokenExpiredEventHandlerArgs args)
        {
            await RefreshAccessToken(args.Id);
        }

        public async Task<string> Auth(Guid id)
        {
            string gmailAuthEndpoint = $"{_configuration["GoogleApi:url"]}?scope={_configuration["GoogleApi:scope"]}&access_type={_configuration["GoogleApi:access_type"]}&response_type={_configuration["GoogleApi:response_type"]}&state={id}&redirect_uri={_configuration["GoogleApi:redirect_uris:code"]}&client_id={_configuration["GoogleApi:client_id"]}";
            return gmailAuthEndpoint;
        }

        public async Task<Profile> GetProfile(Guid id)
        {
            var accessData = await _repository.GetByIdAsync(id);

            if (accessData == null) return null;

            accessData.AccessTokenExpired += AccessTokenExpiredHandler;

            var uri = $"https://gmail.googleapis.com/gmail/v1/users/{accessData.Address}/profile";

            var profile = await _httpRequestService.HttpRequest<Profile>(uri, HttpMethod.Get, accessData.AccessToken);

            accessData.AccessTokenExpired -= AccessTokenExpiredHandler;

            return profile;
        }

        public async Task<List<MessageDto>> GetProfileMessagesAsync(Guid id)
        {
            var accessData = await _repository.GetByIdAsync(id);

            if(accessData is null) throw new ArgumentNullException(nameof(accessData));

            var uri = $"https://gmail.googleapis.com/gmail/v1/users/{accessData.Address}/messages";

            MessagesListDto partialMessages = await _httpRequestService.HttpRequest<MessagesListDto>(uri, HttpMethod.Get, accessData.AccessToken);

            Func<PartialMessageDto, HttpRequestMessage> generateUri = (partialMessage) =>
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{uri}/{partialMessage.Id}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessData.AccessToken);
                return request;
            };

            List<MessageDto> messages = await _httpRequestService.BatchGet<MessageDto, PartialMessageDto>(generateUri, partialMessages.Messages);

            return messages;
        }

        public async Task<GmailDto?> PostAccessCode(string code, string state)
        {
            var uri = $"https://oauth2.googleapis.com/token?client_id={_configuration["GoogleApi:client_id"]}&client_secret={_configuration["GoogleApi:client_secret"]}&code={code}&grant_type=authorization_code&redirect_uri={_configuration["GoogleApi:redirect_uris:code"]}";

            var accessData = await _httpRequestService.HttpRequest<AccessData>(uri, HttpMethod.Post);

            GmailDto gmailDto = new ()
            {
                UserId = new Guid(state),
                AccessToken = accessData.Access_token,
                RefreshToken = accessData.Refresh_token,
                Expires = DateTime.Now.AddSeconds(Convert.ToDouble(accessData.Expires_in)),
            };

            await _repository.CreateAsync(gmailDto);

            return gmailDto;
        }

        public async Task RefreshAccessToken(Guid id)
        {
            var gmail = await _repository.GetByIdAsync(id);

            if(gmail is null)
            {
                return;
            }

            var uri = $"https://oauth2.googleapis.com/token?client_id={_configuration["GoogleApi:client_id"]}&client_secret={_configuration["GoogleApi:client_secret"]}&refresh_token={gmail.RefreshToken}&grant_type=refresh_token";

            var refreshedAccessData = await _httpRequestService.HttpRequest<RefreshedAccessData>(uri, HttpMethod.Post);

            Gmail updatedGmail = new()
            {
                Id = gmail.Id,
                AccessToken = refreshedAccessData.access_token,
                RefreshToken = gmail.RefreshToken,
                Expires = DateTime.Now.AddSeconds(Convert.ToDouble(refreshedAccessData.expires_in)),
                UserId = gmail.UserId,
                Address = gmail.Address,
            };
            await _repository.UpdateAsync(updatedGmail);
        }
    }
}
