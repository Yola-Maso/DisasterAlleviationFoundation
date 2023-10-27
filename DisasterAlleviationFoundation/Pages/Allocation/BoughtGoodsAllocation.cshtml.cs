using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;

namespace DisasterAlleviationFoundation.Pages.Allocation
{
    public class BoughtGoodsAllocationModel : PageModel
    {
        private readonly DisasterAlleviationFoundation.Data.UserContext _context;

        public BoughtGoodsAllocationModel(DisasterAlleviationFoundation.Data.UserContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BuyGoodID"] = new SelectList(_context.BuyGoods, "BuyGoodID", "BuyGoodID");
        ViewData["DisasterID"] = new SelectList(_context.Disaster, "DisasterID", "DisasterID");
            return Page();
        }

        [BindProperty]
        public BoughtGoodsAllocation BoughtGoodsAllocation { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            // Check if the entered DisasterID exists
            if (!_context.Disaster.Any(d => d.DisasterID == BoughtGoodsAllocation.DisasterID))
            {
                ModelState.AddModelError("BoughtGoodsAllocation.DisasterID", "Invalid Disaster ID");
                return Page();
            }

            // Check if the entered BuyGoodID exists
            if (!_context.BuyGoods.Any(b => b.BuyGoodID == BoughtGoodsAllocation.BuyGoodID))
            {
                ModelState.AddModelError("BoughtGoodsAllocation.BuyGoodID", "Invalid Buy Good ID");
                return Page();
            }

            _context.BoughtGoodsAllocation.Add(BoughtGoodsAllocation);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Allocation/BoughtGoodsAllocation");
        }
    }
}