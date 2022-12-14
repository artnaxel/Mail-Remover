using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Models.Gmail;
using System;

namespace MailRemoverAPI.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private HttpClient _httpClient;

        public HttpRequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<T>> BatchGet<T, U>(Func<U, HttpRequestMessage> generateUrl, List<U> queryList)
        {
            var result = new List<T>();
            

            foreach(var query in queryList)
            {
                var request = generateUrl(query);
                var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                var responseBody = await response.Content.ReadAsStringAsync();
                var deserializedResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseBody);

                result.Add(deserializedResponse);
            }

            return result;
        }

        public async Task<T?> HttpRequest<T>(string uri, HttpMethod method, string? bearerToken, HttpContent? content)
        {
            var request = new HttpRequestMessage(method, uri);

            if(bearerToken is not null)
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
            }

            if(content is not null)
            {
                request.Content = content;
            }

            try
            {
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var deserializedResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseBody);

                return deserializedResponse;
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(e.Message);
            }
        }

        public async Task<T?> HttpRequest<T>(string uri, HttpMethod method)
        {
            return await HttpRequest<T>(uri, method, null, null);
        }

        public async Task<T?> HttpRequest<T>(string uri, HttpMethod method, string bearerToken)
        {
            return await HttpRequest<T>(uri, method, bearerToken, null);
        }

        public async Task<T?> HttpRequest<T>(string uri, HttpMethod method, HttpContent content)
        {
            return await HttpRequest<T>(uri, method, null, content);
        }

        public async Task HttpRequest(string uri, HttpMethod method, string? bearerToken, HttpContent? content)
        {
            await HttpRequest<object>(uri, method, bearerToken, content);
        }

        public async Task HttpRequest(string uri, HttpMethod method)
        {
            await HttpRequest(uri, method, null, null);
        }
    }
}
