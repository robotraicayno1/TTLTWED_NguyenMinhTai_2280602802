using Microsoft.EntityFrameworkCore;
namespace NguyenMinhTai_2280602802.Model
{
    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
       options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
