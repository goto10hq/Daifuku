using Daifuku.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sushi2;

namespace Daifuku.Tests
{
    [TestClass]
    public class Middleware
    {
        readonly Mock<HttpContext> httpContextMock = new Mock<HttpContext>();
        protected Mock<HttpResponse> httpResponse = new Mock<HttpResponse>();
        readonly Mock<IHeaderDictionary> httpDictionary = new Mock<IHeaderDictionary>();

        [TestInitialize]
        public void Init()
        {
            httpContextMock.SetupGet(a => a.Response).Returns(httpResponse.Object);
            httpResponse.SetupGet(a => a.Headers).Returns(httpDictionary.Object);
        }

        [TestMethod]
        public void ServerHeaderSet()
        {
            httpDictionary.SetupSet(a => a[Constants.ServerHeader] = "Goto10").Verifiable();
            AsyncTools.RunSync(() => new ServerHeader(null, "Goto10").Invoke(httpContextMock.Object));
            httpDictionary.Verify();
        }

        [TestMethod]
        public void XPoweredByHeaderSet()
        {
            httpDictionary.SetupSet(a => a[Constants.XPoweredBy] = "Goto10").Verifiable();
            AsyncTools.RunSync(() => new XPoweredByHeader(null, "Goto10").Invoke(httpContextMock.Object));
            httpDictionary.Verify();
        }
    }
}