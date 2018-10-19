using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Daifuku.Tests
{
    public class HealthzTests : IClassFixture<WebApplicationFactory<SampleWeb.Program>>
    {
        readonly WebApplicationFactory<SampleWeb.Program> _factory;

        public HealthzTests(WebApplicationFactory<SampleWeb.Program> factory)
        {
            _factory = factory;
        }

        //[Theory]
        //[InlineData("/healthz", HttpStatusCode.NotFound)]
        //[InlineData("/real-healthz", HttpStatusCode.OK)]
        //public async Task Responses(string path, HttpStatusCode code)
        //{
        //    var client = _factory.CreateClient();
        //    var response = await client.GetAsync(path).ConfigureAwait(false);

        //    Assert.Equal(code, response.StatusCode);
        //}
    }
}