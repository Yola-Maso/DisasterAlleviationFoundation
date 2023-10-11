using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;

namespace DisasterAlleviationFoundation.Pages.GoodsCategory
{
    public class CategoryListModel : PageModel
    {
        private readonly DisasterAlleviationFoundation.Data.UserContext _context;

        public CategoryListModel(DisasterAlleviationFoundation.Data.UserContext context)
        {
            _context = context;
        }

        public IList<GoodsCategories> GoodsCategories { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.GoodsCategories != null)
            {
                GoodsCategories = await _context.GoodsCategories.ToListAsync();
            }
        }
    }
}
