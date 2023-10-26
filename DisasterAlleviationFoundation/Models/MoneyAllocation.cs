using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models
{
    public class MoneyAllocation
    {

        [Key]
        public int MoneyAllocationID { get; set; }
        [ForeignKey("Disaster")]
        public int DisasterID { get; set; }
        [ForeignKey("MonetaryDonations")]
        public int MonetaryID { get; set; }
        public decimal Amount { get; set; }

        public Disaster Disaster { get; set; }
        public MonetaryDonations MonetaryDonations { get; set; }

    }
}
