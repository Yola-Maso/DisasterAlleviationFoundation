using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;

namespace DisasterAlleviationFoundation.Pages.GoodsDonation
{
    public class GoodsDonationsListModel : PageModel
    {
        private readonly DisasterAlleviationFoundation.Data.UserContext _context;

        public GoodsDonationsListModel(DisasterAlleviationFoundation.Data.UserContext context)
        {
            _context = context;
        }

        public IList<GoodsDonations> GoodsDonations { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.GoodsDonations != null)
            {
                GoodsDonations = await _context.GoodsDonations.ToListAsync();
            }
        }
    }
}
