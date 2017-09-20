using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VideoAppBLL;
using VideoAppBLL.BO;

namespace VideoRestAPI
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
            var facade = new BLLFacade();
            var vid = facade.VideoAppService.Create(
                new VideoBO()
                {
                    Title = "Bob",
                    pricePrDay = 100,
                    Id = 1

                });
            facade.VideoAppService.Create(
                new VideoBO()
                {
                    Title = "Dad",
                    pricePrDay = 100,
                    Id = 2

                });
            facade.GenreService.Create(new GenreBO()
            {

                Name = "Horror",



            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseMvc();
        }
    }
}
