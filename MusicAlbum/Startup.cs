using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MusicAlbum.Repository.Context;
using MusicAlbum.Repository.Repository;

using MusicAlbum.Service.Service;
using Microsoft.OpenApi.Models;
namespace MusicAlbum
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Music Album", Version = "v1" });
            });

            services.AddDbContext<MusicAlbumContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MusicAlbumConnection")));

            //Now register our services with Autofac container
            var builder = new ContainerBuilder();
            //builder.RegisterType<AlbumRatingsRepository>().As<IAlbumRatingsRepository>();
            //builder.RegisterType<SingerAlbumLinksRepository>().As<ISingerAlbumLinksRepository>();
            builder.RegisterType<SongsRepository>().As<ISongsRepository>();
            builder.RegisterType<SingersRepository>().As<ISingersRepository>();
            builder.RegisterType<AlbumsRepository>().As<IAlbumsRepository>();
            builder.RegisterType<AlbumService>().As<IAlbumService>();
            builder.RegisterType<SingerService>().As<ISingerService>();
            builder.RegisterType<SongService>().As<ISongService>();
            builder.Populate(services);
            var container = builder.Build();
            //Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });

            app.UseHttpsRedirection();
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
