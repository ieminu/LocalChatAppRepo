using LocalChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LocalChatApp.Pages
{
    public class LoginModel : PageModel
    {
        public string ErrorMessage { get; private set; } = string.Empty;

        readonly MyDBContext _context;

        public static bool IsLoggedIn { get; private set; } = false;

        public LoginModel(MyDBContext context)
        {
            _context = context;
        }

        public IActionResult OnPost(string name, string password)
        {
            if (_context.Users.ToList().Count > 0)
            {
                foreach (User user in _context.Users.ToList())
                {
                    if (user.Name.ToLower() == name.ToLower() && user.Password == password)
                    {
                        ErrorMessage = string.Empty;
                        IsLoggedIn = true;

                        ChatModel.SetUsername(user.Username);

                        return RedirectToPage("Index");
                    }

                    ErrorMessage = "Cannot find a registered user with this name and password!";
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
