using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Daifuku.Extensions;

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
            services.AddMvc();
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
            app.UseServerHeader("Daifuku server");

            // set No Mime Sniff
            app.UseNoMimeSniff();

            // set Referrer policy
            app.UseReferrerPolicy(ReferrerPolicy.NoReferrer);

            // set Powered by
            app.UsePoweredBy("Daifuku!");

            // set Frame guard
            app.UseFrameGuard(new FrameGuardOptions(FrameGuard.SameOrigin));

            // set XSS protection
            app.UseXssProtection(XssProtection.EnabledWithBlock);

            // or just forget all settings and use default pipeline :)
            //app.UseDaifuku();

            // configure domain redirects
            app.RedirectDomains(new Dictionary<string, string>
            {
                { "daifu.ku", "www.daifu.ku" },
                { "test.azurewebsites.net", "www.daifu.ku" },
            });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}