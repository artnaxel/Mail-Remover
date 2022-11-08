using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Models.Gmail;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using System.Drawing;
using static Google.Apis.Requests.BatchRequest;

namespace MailRemoverAPI.Services
{
    public class GmailService
    {
        private IConfiguration _configuration;
        public List<string> Codes = new List<string>();
        public List<AccessData> AccessTokens = new List<AccessData>();
        private HttpClient client;

        public GmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            client = new HttpClient();
        }

        public async Task<string> Auth(Guid id)
        {
            string gmailAuthEndpoint = $"{_configuration["GoogleApi:url"]}?scope={_configuration["GoogleApi:scope"]}&access_type={_configuration["GoogleApi:access_type"]}&response_type={_configuration["GoogleApi:response_type"]}&state={id}&redirect_uri={_configuration["GoogleApi:redirect_uris:code"]}&client_id={_configuration["GoogleApi:client_id"]}";
            return gmailAuthEndpoint;
        }

        public async Task<bool> SaveAuthCode(string code)
        {
            Codes.Add(code);
            return true;
        }

        public async Task<string> PostAccessCode(string code)
        {
            Codes.Add(code);

            var values = new Dictionary<string, string>
            {
                { "code", code },
                { "client_id", _configuration["GoogleApi:client_id"] },
                { "client_secret", _configuration["GoogleApi:client_secret"] },
                { "redirect_uri", _configuration["GoogleApi:redirect_uris:token"] },
                { "grant_type", "authorization_code" }
            };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync($"https://oauth2.googleapis.com/token?client_id={ _configuration["GoogleApi:client_id"] }&client_secret={ _configuration["GoogleApi:client_secret"] }&code={ code }&grant_type=authorization_code&redirect_uri={_configuration["GoogleApi:redirect_uris:code"]}", null);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public List<string> GetAllCodes()
        {
            return Codes;
        }
    }
}
