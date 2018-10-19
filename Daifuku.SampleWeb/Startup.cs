using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Daifuku.Extensions;
using Daifuku.Exceptions;
using Daifuku.SampleWeb.Exceptions;

namespace Daifuku.SampleWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(ApplicationExceptionFilter<AppException>));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // set Server
            app.UseServerHeader();

            // set Powered by
            app.UsePoweredBy();

            // set No Mime Sniff
            app.UseNoMimeSniff();

            // set Referrer policy
            app.UseReferrerPolicy(ReferrerPolicy.NoReferrer);

            // set Frame guard
            app.UseFrameGuard(new FrameGuardOptions(FrameGuard.SameOrigin));

            // set XSS protection
            app.UseXssProtection(XssProtection.EnabledWithBlock);

            // or just forget all settings and use default pipeline :)
            app.UseDaifuku();

            // pipeline stuff below is not set in UseDaifuku
            // ---------------------------------------------

            // do we use HTTPS?
            //var options = new RewriteOptions().AddRedirectToHttpsPermanent();
            //app.UseRewriter(options);
            app.UseHsts();

            // configure domain redirects
            app.RedirectDomains(new Dictionary<string, string>
            {
                { "daifu.ku", "www.daifu.ku" },
                { "test.azurewebsites.net", "www.daifu.ku" },
            });

            // set custom header
            app.UseCustomHeader("X-Overlord", "Daifuku");

            // set feature policy
            app.UseFeaturePolicy(new FeaturePolicyBuilder()
            .WithAutoplay(CspConstants.Self)
            .WithAutoplay("http://*.daifu.ku")
            .WithGeolocation(CspConstants.None)
            .BuildPolicy());

            // set content security policy
            app.UseContentSecurityPolicy(new ContentSecurityPolicyBuilder()
              .WithDefaultSource(CspConstants.Self)
              .WithImageSource("*")
              .WithFontSource(CspConstants.Self)
              .WithFrameAncestors(CspConstants.None)
              .WithMediaSource(Schemes.MediaStream)
              .BuildPolicy());

            // set Expect CT
            app.UseExpectCt(86400, "https://daifu.ku/report");

            // run healthz endpoint
            app.UseHealthz("/real-healthz");

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}