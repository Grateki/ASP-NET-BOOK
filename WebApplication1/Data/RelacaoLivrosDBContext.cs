using ControleDeLivros.Data.Map;
using ControleDeLivros.Models;
using Microsoft.EntityFrameworkCore;


namespace ControleDeLivros.Data
{
    public class RelacaoLivrosDBContext : DbContext 
    {
        public RelacaoLivrosDBContext(DbContextOptions<RelacaoLivrosDBContext> options): base(options) 
        {

        }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new BookMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
