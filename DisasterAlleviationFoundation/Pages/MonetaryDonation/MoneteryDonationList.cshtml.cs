using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;

namespace DisasterAlleviationFoundation.Pages.MonetaryDonation
{
    public class MoneteryDonationListModel : PageModel
    {
        private readonly DisasterAlleviationFoundation.Data.UserContext _context;

        public MoneteryDonationListModel(DisasterAlleviationFoundation.Data.UserContext context)
        {
            _context = context;
        }

        public IList<MonetaryDonations> MonetaryDonations { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MonetaryDonations != null)
            {
                MonetaryDonations = await _context.MonetaryDonations.ToListAsync();
            }
        }
    }
}
