using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace LocalChatApp.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

        public void OnGet()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User;

            if (claimsPrincipal.Identity is not null && claimsPrincipal.Identity.IsAuthenticated)
            {
                LoginModel.IsLoggedIn = true;
            }

            if (LoginModel.IsLoggedIn)
            {
                ChatModel.Username = HttpContext.User.Claims.ElementAt(1).Value;
            }
        }
    }
}