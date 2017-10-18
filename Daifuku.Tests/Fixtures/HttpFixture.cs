using Microsoft.AspNetCore.Http;
using Moq;
using System;

namespace Daifuku.Tests.Fixtures
{
    public class HttpFixture : IDisposable
    {
        public Mock<HttpContext> ContextMock = new Mock<HttpContext>();
        public Mock<HttpResponse> Response = new Mock<HttpResponse>();
        public Mock<IHeaderDictionary> Header = new Mock<IHeaderDictionary>();

        public HttpFixture()
        {
            ContextMock.SetupGet(a => a.Response).Returns(Response.Object);
            Response.SetupGet(a => a.Headers).Returns(Header.Object);
        }

        public void Dispose()
        {
        }
    }
}