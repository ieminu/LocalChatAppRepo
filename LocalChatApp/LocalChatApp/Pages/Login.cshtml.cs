using LocalChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LocalChatApp.Pages
{
    public class LoginModel : PageModel
    {
        //Add showing password mechanism

        public string ErrorMessage { get; private set; } = string.Empty;

        readonly MyDBContext _context;

        public static bool IsLoggedIn { get; private set; } = false;

        public LoginModel(MyDBContext context)
        {
            _context = context;
        }

        public IActionResult OnPost(string username, string password)
        {
            if (_context.Users.ToList().Count > 0)
            {
                foreach (User user in _context.Users.ToList())
                {
                    if (user.Username?.ToLower() == username.ToLower() && user.Password == password)
                    {
                        ErrorMessage = string.Empty;
                        IsLoggedIn = true;
                        ChatModel.SetUsername(username);

                        return RedirectToPage("Index");
                    }

                    ErrorMessage = "Cannot find a registered user with this username and password!";
                }

                return Page();
            }

            else
            {
                ErrorMessage = "Cannot find a registered user!";
                return Page();
            }
        }
    }
}
