using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models
{
    public class BuyGoods
    {

        [Key]
        public int BuyGoodID { get; set; }

        public int NumOfItems { get; set; }

        //[ForeignKey("Category")]
        //public int CategoryID { get; set; }

        public string Description { get; set; }

        //public bool IsAnonymous { get; set; }

        public string CategoryName { get; set; }

        public decimal Amount { get; set; }

    }
}
