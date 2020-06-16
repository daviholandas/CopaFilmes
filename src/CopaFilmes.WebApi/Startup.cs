using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.WebApi.Config;
using CopaFilmes.WebApi.Services;
using CopaFilmes.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CopaFilmes.WebApi
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
            services.AddControllers();

            //Configuração do consumo api externa
            services.Configure<ApiExternaConfig>(Configuration.GetSection(nameof(ApiExternaConfig)));
            services.AddSingleton<IApiExternaConfig>(s
                => s.GetRequiredService <IOptions<ApiExternaConfig>>().Value);
            services.AddHttpClient<IApiFilmesService, ApiFilmesService>(s 
                =>s.BaseAddress = new Uri(Configuration["ApiExternaConfig:BaseUrl"]));

            //Versionamento
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVv";
                options.SubstituteApiVersionInUrl = true;
            });

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
