using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;

namespace DisasterAlleviationFoundation.Pages.BuyGood
{
    public class BuyGoodsModel : PageModel
    {
        private readonly DisasterAlleviationFoundation.Data.UserContext _context;

        public BuyGoodsModel(DisasterAlleviationFoundation.Data.UserContext context)
        {
            _context = context;
        }

         public decimal AvailableMoney { get; private set; }

        public IActionResult OnGet()
        {
            // Calculate available money when the page is loaded
            CalculateAvailableMoney();
            return Page();
        }

        [BindProperty]
        public BuyGoods BuyGoods { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
        

            // Calculate available money before processing the purchase
            CalculateAvailableMoney();

            // Check if the amount entered by the user is more than the available money
            if (BuyGoods.Amount > AvailableMoney)
            {
                ModelState.AddModelError("BuyGoods.Amount", "Insufficient funds.");
                return Page();
            }

            // Deduct the purchase amount from the available money
            AvailableMoney -= BuyGoods.Amount;

            _context.BuyGoods.Add(BuyGoods);
            await _context.SaveChangesAsync();

            return RedirectToPage("/BuyGood/BuyGoods");
        }

        private void CalculateAvailableMoney()
        {
            // Example: Query the total amount donated from MonetaryDonations
            var totalDonated = _context.MonetaryDonations.Sum(d => d.Amount);

            // Example: Query the total amount allocated to disasters from MoneyAllocation
            var totalAllocated = _context.MoneyAllocation.Sum(a => a.Amount);

            // Example: Query the total amount spent from BuyGoods
            var totalSpent = _context.BuyGoods.Sum(b => b.Amount);

            // Calculate the available money by subtracting the allocated and spent amounts from the total donated
            AvailableMoney = totalDonated - totalAllocated - totalSpent;

            // Ensure available money is non-negative
            AvailableMoney = Math.Max(AvailableMoney, 0);
        }
    }
}