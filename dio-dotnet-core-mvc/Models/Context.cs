using Microsoft.EntityFrameworkCore;

namespace dio_dotnet_core_mvc.Models
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
