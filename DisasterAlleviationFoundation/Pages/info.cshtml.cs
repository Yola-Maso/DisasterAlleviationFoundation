using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;

namespace DisasterAlleviationFoundation.Pages
{
    public class infoModel : PageModel
    {
        private readonly UserContext _context;

        public infoModel(UserContext context)
        {
            _context = context;
        }

        public decimal TotalMonetaryDonations { get; set; }
        public int TotalGoodsDonations { get; set; }
        public List<DisasterWithAllocation> ActiveDisasters { get; set; }

        public void OnGet()
        {
            // Calculate total monetary donations
            TotalMonetaryDonations = _context.MonetaryDonations.Sum(d => d.Amount);

            // Calculate total number of goods donations
            TotalGoodsDonations = _context.GoodsDonations.Sum(g => g.NumOfItems);

            // Get currently active disasters with allocated money and goods
            ActiveDisasters = _context.Disaster
                .Where(d => d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now)
                .Select(d => new DisasterWithAllocation
                {
                    DisasterID = d.DisasterID,
                    StartDate = d.StartDate,
                    EndDate = d.EndDate,
                    Location = d.Location,
                    Description = d.Description,
                    TotalMonetaryDonations = _context.MoneyAllocation
                                                .Where(m => m.DisasterID == d.DisasterID)
                                                .Join(_context.MonetaryDonations,
                                                    ma => ma.MonetaryID,
                                                    md => md.MonetaryID,
                                                    (ma, md) => md.Amount)
                                                .Sum(),
                    TotalGoodsDonations = _context.GoodsAllocation
                                                .Where(g => g.DisasterID == d.DisasterID)
                                                .Join(_context.GoodsDonations,
                                                    ga => ga.GoodID,
                                                    gd => gd.GoodID,
                                                    (ga, gd) => gd.NumOfItems)
                                                .Sum(),
                    TotalBoughtGoodsDonations = _context.BoughtGoodsAllocation
                                                .Where(bg => bg.DisasterID == d.DisasterID)
                                                .Join(_context.BuyGoods,
                                                    bga => bga.BuyGoodID,
                                                    bg => bg.BuyGoodID,
                                                    (bga, bg) => bg.NumOfItems)
                                                .Sum()
                })
                .ToList();
        }

        public class DisasterWithAllocation
        {
            public int DisasterID { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public decimal TotalMonetaryDonations { get; set; }
            public int TotalGoodsDonations { get; set; }
            public int TotalBoughtGoodsDonations { get; set; }
        }
    }
}
