using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DisasterAlleviationFoundation.Models
{
    public class GoodsDonations
    {
        [Key]
        public int GoodID { get; set; }

        //[ForeignKey("User")]
        //public int UserID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int NumOfItems { get; set; }

        //[ForeignKey("Category")]
        //public int CategoryID { get; set; }

        public string Description { get; set; }

        public bool IsAnonymous { get; set; }

        public string CategoryName { get; set; }

    }
}
