using Microsoft.EntityFrameworkCore;
using DisasterAlleviationFoundation.Models;

namespace DisasterAlleviationFoundation.Data
{
    public class UserContext : DbContext
    {

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<GoodsCategories> GoodsCategories { get; set; }
        public DbSet<GoodsDonations> GoodsDonations { get; set; }
        public DbSet<MonetaryDonations> MonetaryDonations { get; set; }
        public DbSet<Disaster> Disaster { get; set; }
    }
}

