using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests
{
    public class BaseTest
        : IClassFixture<WebApplicationFactory<Program>>
    {
        public readonly WebApplicationFactory<Program> _factory;

        public BaseTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            
        }
    }
}
