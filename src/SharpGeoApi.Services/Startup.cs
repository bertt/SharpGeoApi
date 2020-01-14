using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using SharpGeoApi.Core;
using SharpGeoApi.Formatters;
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
                    typeof(Collections).IsAssignableFrom(type) ? "Collections" :
                    typeof(Processes).IsAssignableFrom(type) ? "Processes" :
                    typeof(Dataset).IsAssignableFrom(type) ? "Dataset" :
                    typeof(FeatureCollection).IsAssignableFrom(type) ? "FeatureCollection" :
                    string.Empty));
            });

            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddRazorPages().AddNewtonsoftJson();


            services.AddControllers(options => {
                // Prevent the following exception: 'This method does not     support GeometryCollection arguments' 
                // See: https://github.com/npgsql/Npgsql.EntityFrameworkCore.PostgreSQL/issues/585 
                options.ModelMetadataDetailsProviders.Add(new SuppressChildValidationMetadataProvider(typeof(Point)));
                options.ModelMetadataDetailsProviders.Add(new SuppressChildValidationMetadataProvider(typeof(Coordinate)));
                options.ModelMetadataDetailsProviders.Add(new SuppressChildValidationMetadataProvider(typeof(LineString)));
                options.ModelMetadataDetailsProviders.Add(new SuppressChildValidationMetadataProvider(typeof(MultiLineString)));
            }).AddNewtonsoftJson(options => {
                foreach (var converter in NetTopologySuite.IO.GeoJsonSerializer.Create(new GeometryFactory(new PrecisionModel(), 4326)).Converters)
                {
                    options.SerializerSettings.Converters.Add(converter);
                }
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            var datasets = Configuration.GetSection("datasets");
            services.Configure<List<Dataset>>(datasets);
            services.Configure<Metadata>(Configuration.GetSection("metadata"));
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
