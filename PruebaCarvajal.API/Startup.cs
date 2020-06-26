using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PruebaCarvajal.Repository.Interfaces;
using PruebaCarvajal.Repository.SQLImplementations;
using PruebaCarvajal.Service.Interfaces;
using PruebaCarvajal.Service.ServiceImplementations;

namespace PruebaCarvajal.API
{
    public class Startup
    {
        private readonly IConfiguration conf;

        public Startup(IConfiguration _conf)
        {
            conf = _conf;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Carvajal Test v1", Version = "v1" });
            });

            services.AddDbContext<CarvajalContext>(options => options.UseSqlServer(conf["ConnectionStrings:CarvajalConnection"]));

            // Repository DI Containers
            services.AddTransient<ITipoDocumentoRepository, TipoDocumentoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            // Services DI Containers
            services.AddTransient<ITipoDocumentoService, TipoDocumentoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddAutoMapper(typeof(Startup));
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Carvajal Test v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
