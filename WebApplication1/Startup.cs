using ControleDeLivros.Data;
using ControleDeLivros.Repository.Interfaces;
using ControleDeLivros.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ControleDeLivros.Services.Implementation;
using ControleDeLivros.Services.Interfaces;
using ControleDeLivros.Services;
using Microsoft.Extensions.Options;

namespace WebApplication1
{
    public class Startup
    {

        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            // .AddRazorOptions(options =>
            //   {

            //  options.AreaViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
            //  options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            //    options.AreaViewLocationFormats.Add("/Views/Autor/{0}.cshtml");
            //  options.AreaViewLocationFormats.Add("/Views/Livro/{0}.cshtml");
            //   });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddEntityFrameworkSqlite().AddDbContext<RelacaoLivrosDBContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DataBase"))
            );

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBooksRepository, BookRepository>();
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<IBookService, BookService>();


            var datab = services.BuildServiceProvider();
            using (var scope = datab.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<RelacaoLivrosDBContext>();
                db.Database.EnsureCreated();
            }

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
