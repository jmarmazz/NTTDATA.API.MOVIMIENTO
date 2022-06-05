using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NTTDATA.APPLICATION.AppServices;
using NTTDATA.APPLICATION.Interfaces.AppServices;
using NTTDATA.DOMAIN.Interfaces.Repositories;
using NTTDATA.INFRA.REPOSITORY.SQLSERVER.Models;
using NTTDATA.INFRA.REPOSITORY.SQLSERVER.Repositories;
using NTTDATA.QUERY.Interfaces.QueryServices;
using NTTDATA.QUERY.SQLSERVER.Models;
using NTTDATA.QUERY.SQLSERVER.QueryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTTDATA.API.MOVIMIENTO
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
            
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IClienteQueryService, ClienteQueryService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICuentaAppService, CuentaAppService>();
            services.AddScoped<ICuentaQueryService, CuentaQueryService>();
            services.AddScoped<ICuentaRepository, CuentaRepository>(); 
            services.AddScoped<IMovimientoQueryService, MovimientoQueryService>();
            services.AddScoped<IMovimientoAppService, MovimientoAppService>();
            services.AddScoped<IMovimientoRepository, MovimientoRepository>(); 

            var CadenaConexion = Configuration.GetSection("DB").GetSection("DataSource").Value;  
            services.AddDbContext<QueryContext>(options => options.UseSqlServer(CadenaConexion)); 
            services.AddDbContext<CmdContext>(options => options.UseSqlServer(CadenaConexion));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NTTDATA.API.MOVIMIENTO", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NTTDATA.API.MOVIMIENTO v1"));
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
