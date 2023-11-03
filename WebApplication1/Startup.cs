using ControleDeLivros.Data;
using ControleDeLivros.Repository.Interfaces;
using ControleDeLivros.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ControleDeLivros.Services.Implementation;
using ControleDeLivros.Services.Interfaces;
using ControleDeLivros.Services;

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
            // Configure services here
            services.AddControllers();
            services.AddControllersWithViews()
            .AddRazorOptions(options =>
            {
                options.AreaViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Autor/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Livro/{0}.cshtml");
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<RelacaoLivrosDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DataBase"))
            );

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBooksRepository, BookRepository>();
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<IBookService, BookService>();

            // Adicione outras configurações de serviços conforme necessário
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configure middleware here
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();
            app.UseAuthorization();
        }
    }
}
