using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SharpGeoApi.Core;
using SharpGeoApi.Formatters;
using SharpGeoApi.Services.FormatFilters;
using System.Collections.Generic;

namespace SharpGeoApi
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
            services.AddControllers(options => {
                options.RespectBrowserAcceptHeader=true;
            }).AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; });

            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new RazorOutputFormatter(type =>
                    typeof(Root).IsAssignableFrom(type) ? "Root" :
                    typeof(Conformance).IsAssignableFrom(type) ? "Conformance" :
                    typeof(FeatureCollections).IsAssignableFrom(type) ? "FeatureCollections" :
                    typeof(Processes).IsAssignableFrom(type) ? "Processes" :
                    string.Empty));
                options.FormatterMappings.SetMediaTypeMappingForFormat("html", new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            });


            services.Configure<List<Dataset>>(Configuration.GetSection("datasets"));
            services.Replace(ServiceDescriptor.Singleton<FormatFilter, CustomFormatFilter>());
            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHsts();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
