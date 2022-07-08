using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudentManagerment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace StudentManagerment
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All));
            services.AddControllersWithViews().AddMvcOptions(options => options.EnableEndpointRouting = false);
            services.AddControllersWithViews().AddXmlSerializerFormatters();
            //services.AddSingleton();
            //services.AddTransient();
            //services.AddScoped();
            services.AddSingleton<IStudentRepository, MockStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("test.html");
            //app.UseDefaultFiles(defaultFilesOptions);//默认文件中间件 终端中间件
            //app.UseStaticFiles();//静态文件中间件
            //app.UseFileServer();

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
           

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //  throw new Exception("aaaa");
                    await context.Response.WriteAsync($"Hosting Environment {env.EnvironmentName}");
                });

            });
        }
    }
}
