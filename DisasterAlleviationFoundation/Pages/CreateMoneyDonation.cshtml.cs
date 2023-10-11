using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviationFoundation.Pages
{
    public class CreateMoneyDonationModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public CreateMoneyDonationModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
