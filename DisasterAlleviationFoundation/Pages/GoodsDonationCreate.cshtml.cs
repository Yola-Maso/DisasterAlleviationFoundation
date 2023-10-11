using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviationFoundation.Pages
{
    public class GoodsDonationCreateModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public GoodsDonationCreateModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
