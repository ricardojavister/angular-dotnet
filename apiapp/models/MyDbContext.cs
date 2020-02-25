using Microsoft.EntityFrameworkCore;

namespace apiapp.models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base (options){

        }
        public DbSet<product> Product { get; set; }
    }
}