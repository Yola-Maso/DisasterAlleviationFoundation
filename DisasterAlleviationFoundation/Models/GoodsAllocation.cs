using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models
{
    public class GoodsAllocation
    {
        [Key]
        public int GoodsAllocationID { get; set; }
        [ForeignKey("Disaster")]
        public int DisasterID { get; set; }
        [ForeignKey("GoodsDonations")]
        public int GoodID { get; set; }


        public Disaster Disaster { get; set; }
        public GoodsDonations GoodsDonations { get; set; }
    }
}
