using AgendaClinicaVivaEstetica.DAL.Contextos;
using AgendaClinicaVivaEstetica.DAL.Repositorios;
using AgendaClinicaVivaEstetica.Dominio.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaClinicaVivaEstetica.Apresentacao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Trabalha com o banco de dados em memoria em tempo de execução. Descomentar/Comentar a de baixo para utilizar.
            services.AddDbContext<DbContexto>(options => options.UseInMemoryDatabase("DefaultConnection"));

            //Trabalha com o banco de dados fisico utilizando SqlServer. Descomentar/Comentar a de cima para utilizar.
            //services.AddDbContext<DbContexto>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IRepositorioCliente, RepositorioCliente>();
            services.AddTransient<IRepositorioMarcacao, RepositorioMarcacao>();

            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Marcacao}/{action=Index}/{id?}");
            });
        }
    }
}
