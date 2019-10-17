using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SharpGeoApi.Services.FormatFilters;
using SharpGeoApi.Services.Formatters;

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
            services
                .AddControllers(opt => opt.OutputFormatters.Add(new HtmlMediaTypeFormatter()))
                .AddXmlSerializerFormatters().
                AddJsonOptions(options => {options.JsonSerializerOptions.IgnoreNullValues = true;});
            services.AddMvc(opt => opt.FormatterMappings.SetMediaTypeMappingForFormat("html", new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("text/html")));
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
