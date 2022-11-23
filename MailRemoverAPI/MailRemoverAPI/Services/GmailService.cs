using MailRemoverAPI.Entities;
using MailRemoverAPI.Events;
using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Models.Gmail;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MailRemoverAPI.Services
{
    public class GmailService : IGmailService
    {
        private IConfiguration _configuration;
        private IGmailRepository _repository;
        private HttpClient client;

        public GmailService(IConfiguration configuration, IGmailRepository repository)
        {
            _configuration = configuration;
            client = new HttpClient();
            _repository = repository;
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

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://gmail.googleapis.com/gmail/v1/users/{accessData.Address}/profile");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessData.AccessToken);

            accessData.AccessTokenExpired -= AccessTokenExpiredHandler;
            try
            {
                HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                var responseBody = await response.Content.ReadAsStringAsync();

                Profile profile = Newtonsoft.Json.JsonConvert.DeserializeObject<Profile>(responseBody);

                return profile;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            throw new NotImplementedException();
        }

        public async Task<GmailDto?> PostAccessCode(string code, string state)
        {

            try
            {
                using HttpResponseMessage response = await client.PostAsync($"https://oauth2.googleapis.com/token?client_id={_configuration["GoogleApi:client_id"]}&client_secret={_configuration["GoogleApi:client_secret"]}&code={code}&grant_type=authorization_code&redirect_uri={_configuration["GoogleApi:redirect_uris:code"]}", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();


                AccessData accessData = Newtonsoft.Json.JsonConvert.DeserializeObject<AccessData>(responseBody);
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
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }

        public async Task RefreshAccessToken(Guid id)
        {
            var gmail = await _repository.GetByIdAsync(id);

            

            if(gmail is null)
            {
                return;
            }

            try
            {
                using HttpResponseMessage response = await client.PostAsync($"https://oauth2.googleapis.com/token?client_id={_configuration["GoogleApi:client_id"]}&client_secret={_configuration["GoogleApi:client_secret"]}&refresh_token={gmail.RefreshToken}&grant_type=refresh_token", null);
                var responseBody = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

                RefreshedAccessData refreshedAccessData = Newtonsoft.Json.JsonConvert.DeserializeObject<RefreshedAccessData>(responseBody);
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
            catch (HttpRequestException e)
            {

            }
        }
    }
}
