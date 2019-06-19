using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogJoaoPedroLeagueofLegends.AutoMapper;
using BlogJoaoPedroLeagueofLegends.DoMain.Interfaces;
using BlogJoaoPedroLeagueofLegends.DoMain.Services;
using BlogJoaoPedroLeagueofLegends.Infra.Context;
using BlogJoaoPedroLeagueofLegends.Infra.Repositories;
using BlogJoaoPedroLeagueofLegends.Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogJoaoPedroLeagueofLegends
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Banco LOCALDB
            var caminhoDoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory());
            var stringConexao = string.Format(@"Server=(localdb)\mssqllocaldb; Initial Catalog= Blog_DB; Integrated Security=true; AttachDBFilename= {0}\Blog_DB", caminhoDoBanco);
            //Banco SQLSERVER
            //var stringConexao = @"Server=LAPTOP-KFKM8RAH\SQLEXPRESS; user= sa; password=123; Initial Catalog=Blog_db";
            //Entity/StringBanco
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(stringConexao));

            //Services
            services.AddTransient<IPostsServices, PostsServices>();
            services.AddTransient<ICategoriaServices, CategoriaServices>();
            //Repository
            services.AddTransient<IPostsRepository, PostsRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();

            MapConfiguration.RegisterMapProfile();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
