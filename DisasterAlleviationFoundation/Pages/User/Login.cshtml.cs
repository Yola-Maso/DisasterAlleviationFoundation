using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;

namespace DisasterAlleviationFoundation.Pages.User
{
    public class LoginModel : PageModel
    {
        private readonly DisasterAlleviationFoundation.Data.UserContext _context;

        public LoginModel(DisasterAlleviationFoundation.Data.UserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Users Users { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public IList<Users> Login { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
 
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username.Trim() == Users.Username.Trim() && u.Password.Trim() == Users.Password.Trim());


            if (user != null)
            {
                // User exists, redirect to a new page or perform any other necessary action
                return RedirectToPage("/Home"); // Change "LoggedInPage" to the desired page
            }
            else
            {
                // If username/password is incorrect or validation fails, stay on the login page
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return Page();
            }
        }
    }
}
