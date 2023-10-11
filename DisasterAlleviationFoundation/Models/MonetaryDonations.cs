using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System;

namespace DisasterAlleviationFoundation.Models
{
    public class MonetaryDonations
    {
        [Key]
        public int MonetaryID { get; set; }

        //[ForeignKey("User")]
        //public int UserID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public bool IsAnonymous { get; set; }

    }
}
