using Microsoft.EntityFrameworkCore;

namespace AngularApi.Model
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext>options):base(options) {
        }  
        public DbSet<User>users { get; set; }
        public DbSet<stockProduct> stockProducts { get; set; }
        public DbSet<stockPurchase> stockPurchase { get; set; }
        public DbSet<stockSale>stockSales { get; set; }
        public DbSet<stockTable> stockTable { get; set; }
    }
}
