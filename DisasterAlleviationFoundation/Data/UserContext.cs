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
        public DbSet<GoodsAllocation> GoodsAllocation { get; set; }
        public DbSet<MoneyAllocation> MoneyAllocation { get; set; }
        public DbSet<BuyGoods> BuyGoods { get; set; }
        public DbSet<DisasterAlleviationFoundation.Models.BoughtGoodsAllocation>? BoughtGoodsAllocation { get; set; }
    }
}

