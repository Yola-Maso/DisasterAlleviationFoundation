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
    public class MoneyAllocationModel : PageModel
    {
        private readonly DisasterAlleviationFoundation.Data.UserContext _context;

        public MoneyAllocationModel(DisasterAlleviationFoundation.Data.UserContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DisasterID"] = new SelectList(_context.Disaster, "DisasterID", "DisasterID");
        ViewData["MonetaryID"] = new SelectList(_context.MonetaryDonations, "MonetaryID", "MonetaryID");
            return Page();
        }

        [BindProperty]
        public MoneyAllocation MoneyAllocation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the DisasterID exists in the Disaster table
            if (!_context.Disaster.Any(d => d.DisasterID == MoneyAllocation.DisasterID))
            {
                ModelState.AddModelError(nameof(MoneyAllocation.DisasterID), "Invalid DisasterID");
                return Page();
            }

            // Retrieve the MonetaryDonation based on MonetaryID
            var monetaryDonation = await _context.MonetaryDonations
                .Where(md => md.MonetaryID == MoneyAllocation.MonetaryID)
                .FirstOrDefaultAsync();

            // Check if the MonetaryID exists in the MonetaryDonations table
            if (monetaryDonation == null)
            {
                ModelState.AddModelError(nameof(MoneyAllocation.MonetaryID), "Invalid MonetaryID");
                return Page();
            }

            // Assign the amount from the MonetaryDonation to MoneyAllocation.Amount
            MoneyAllocation.Amount = monetaryDonation.Amount;

            // Add the MoneyAllocation to the context and save changes
            _context.MoneyAllocation.Add(MoneyAllocation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
