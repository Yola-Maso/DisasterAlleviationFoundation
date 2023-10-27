using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models
{
    public class BoughtGoodsAllocation
    {

        [Key]
        public int BoughtGoodsAllocationID { get; set; }
        [ForeignKey("Disaster")]
        public int DisasterID { get; set; }
        [ForeignKey("BuyGoods")]
        public int BuyGoodID { get; set; }

        public Disaster Disaster { get; set; }
        public BuyGoods BuyGoods { get; set; }
    }
}
