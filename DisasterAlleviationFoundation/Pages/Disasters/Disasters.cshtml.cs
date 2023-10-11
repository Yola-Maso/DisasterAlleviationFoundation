using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;

namespace DisasterAlleviationFoundation.Pages.Disasters
{
    public class DisastersModel : PageModel
    {
        private readonly DisasterAlleviationFoundation.Data.UserContext _context;

        public DisastersModel(DisasterAlleviationFoundation.Data.UserContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Disaster Disaster { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Disaster == null || Disaster == null)
            {
                return Page();
            }

            _context.Disaster.Add(Disaster);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
