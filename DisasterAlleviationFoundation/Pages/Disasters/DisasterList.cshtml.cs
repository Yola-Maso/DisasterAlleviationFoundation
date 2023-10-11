using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;

namespace DisasterAlleviationFoundation.Pages.Disasters
{
    public class DisasterListModel : PageModel
    {
        private readonly DisasterAlleviationFoundation.Data.UserContext _context;

        public DisasterListModel(DisasterAlleviationFoundation.Data.UserContext context)
        {
            _context = context;
        }

        public IList<Disaster> Disaster { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Disaster != null)
            {
                Disaster = await _context.Disaster.ToListAsync();
            }
        }
    }
}
