using Microsoft.EntityFrameworkCore;

namespace JsonApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Video> Videos { get; set; }
    }
}
