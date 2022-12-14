namespace MailRemoverAPI.Interfaces
{
    public interface IHttpRequestService
    {
        public Task HttpRequest(string uri, HttpMethod method, string? bearerToken, HttpContent? content);

        public Task<T> HttpRequest<T>(string uri, HttpMethod method, string? bearerToken, HttpContent? content);

        public Task<T> HttpRequest<T>(string uri, HttpMethod method, string bearerToken);

        public Task<T> HttpRequest<T>(string uri, HttpMethod method, HttpContent content);

        public Task<T?> HttpRequest<T>(string uri, HttpMethod method);

        public Task<List<T>> BatchGet<T, U>(Func<U, HttpRequestMessage> generateUrl, List<U> queryList);
    }
}
