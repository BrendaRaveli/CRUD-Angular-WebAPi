using Microsoft.EntityFrameworkCore;


namespace CRUDAPI.models
{
    public class MeuDbContext : DbContext
    
    {
        public DbSet<Pessoa> Pessoas {get;set;}

        public MeuDbContext(DbContextOptions<MeuDbContext> options) :base(options)
        {

        }

    }
}