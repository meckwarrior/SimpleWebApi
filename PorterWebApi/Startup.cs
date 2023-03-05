using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PorterWebApi.Application;
using PorterWebApi.Application.Interfaces;
using PorterWebApi.Domain.Interfaces.Repositories;
using PorterWebApi.Domain.Interfaces.Services;
using PorterWebApi.Domain.Services;
using PorterWebApi.Infra.Data.Context;
using PorterWebApi.Infra.Data.Repositories;

namespace PorterWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionService.Set(configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Porter API", Version = "v1" });
            });

            services.AddScoped<ICondominioAppService, CondominioAppService>();
            services.AddScoped<IBlocoAppService, BlocoAppService>();
            services.AddScoped<IApartamentoAppService, ApartamentoAppService>();
            services.AddScoped<IMoradorAppService, MoradorAppService>();

            services.AddScoped<ICondominioService, CondominioService>();
            services.AddScoped<IBlocoService, BlocoService>();
            services.AddScoped<IApartamentoService, ApartamentoService>();
            services.AddScoped<IMoradorService, MoradorService>();

            services.AddScoped<ICondominioRepository, CondominioRepository>();
            services.AddScoped<IBlocoRepository, BlocoRepository>();
            services.AddScoped<IApartamentoRepository, ApartamentoRepository>();
            services.AddScoped<IMoradorRepository, MoradorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Porter API v1");
            });

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
