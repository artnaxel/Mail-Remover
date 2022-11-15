﻿using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Models.Gmail;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Text.Json;
using static Google.Apis.Requests.BatchRequest;

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

        public async Task<string> Auth(Guid id)
        {
            string gmailAuthEndpoint = $"{_configuration["GoogleApi:url"]}?scope={_configuration["GoogleApi:scope"]}&access_type={_configuration["GoogleApi:access_type"]}&response_type={_configuration["GoogleApi:response_type"]}&state={id}&redirect_uri={_configuration["GoogleApi:redirect_uris:code"]}&client_id={_configuration["GoogleApi:client_id"]}";
            return gmailAuthEndpoint;
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
    }
}
