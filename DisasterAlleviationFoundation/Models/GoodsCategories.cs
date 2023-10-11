using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DisasterAlleviationFoundation.Models
{
    public class GoodsCategories
    {

        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

       // [ForeignKey("User")]
       // public int UserID { get; set; }


    }
}
