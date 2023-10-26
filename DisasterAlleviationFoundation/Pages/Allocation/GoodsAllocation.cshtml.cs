using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;
using Microsoft.EntityFrameworkCore;

namespace DisasterAlleviationFoundation.Pages.Allocation
{
    public class GoodsAllocationModel : PageModel
    {
        private readonly DisasterAlleviationFoundation.Data.UserContext _context;

        public GoodsAllocationModel(DisasterAlleviationFoundation.Data.UserContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DisasterID"] = new SelectList(_context.Disaster, "DisasterID", "DisasterID");
        ViewData["GoodID"] = new SelectList(_context.GoodsDonations, "GoodID", "GoodID");
            return Page();
        }

        [BindProperty]
        public GoodsAllocation GoodsAllocation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
           

            // Check if the specified DisasterID exists
            var disasterExists = await _context.Disaster.AnyAsync(d => d.DisasterID == GoodsAllocation.DisasterID);
            if (!disasterExists)
            {
                ModelState.AddModelError(string.Empty, "Disaster with the specified ID does not exist.");
                return Page();
            }

            // Check if the specified GoodID exists
            var goodExists = await _context.GoodsDonations.AnyAsync(g => g.GoodID == GoodsAllocation.GoodID);
            if (!goodExists)
            {
                ModelState.AddModelError(string.Empty, "Goods donation with the specified ID does not exist.");
                return Page();
            }

            // Both DisasterID and GoodID are valid, proceed with adding the allocation
            _context.GoodsAllocation.Add(GoodsAllocation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

