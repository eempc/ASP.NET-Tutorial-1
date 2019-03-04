using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore; // Required for the DBcontext
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Static stuff is in wwww.root (use static files?) like css, images, js
// Pages is the razor pages

namespace WebApplication1 {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            // Database Step 1: Add this line then create the AppDbContext.cs file
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("name")); //AppDbContext is a class .cs file that needs to be generated (ctrl + .)
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
            // might need to declare default routes?
        }
    }
}
