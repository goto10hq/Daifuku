using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Daifuku.Tests.Helpers
{
    public class EmptyModelMetadataProvider : DefaultModelMetadataProvider
    {
        public EmptyModelMetadataProvider()
            : base(
                  new DefaultCompositeMetadataDetailsProvider(new List<IMetadataDetailsProvider>()),
                  new OptionsAccessor())
        {
        }

        class OptionsAccessor : IOptions<MvcOptions>
        {
            public MvcOptions Value { get; } = new MvcOptions();
        }
    }
}