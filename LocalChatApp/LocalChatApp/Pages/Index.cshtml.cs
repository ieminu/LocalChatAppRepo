using LocalChatApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace LocalChatApp.Pages
{
	public class IndexModel : PageModel
	{
        private readonly MyDBContext _context;

        public IndexModel(MyDBContext context) 
        {
            _context = context;
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

            RegisterModel.SetUsers(_context);
        }
    }
}