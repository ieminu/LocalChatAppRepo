using LocalChatApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace LocalChatApp.Pages
{
    public class LoginModel : PageModel
    {
        public string ErrorMessage { get; private set; } = string.Empty;

        readonly MyDBContext _context;

        public static bool IsLoggedIn { get; set; }

        bool redirectToPage = false;

        public LoginModel(MyDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User;

            if (claimsPrincipal.Identity is not null && claimsPrincipal.Identity.IsAuthenticated)
            {
                IsLoggedIn = true;
                return RedirectToPage("Index");
            }

            else
                return Page();
        }

        public IActionResult OnPost(string name, string password)
        {
            _ = Login(name, password);

            return redirectToPage == true ? RedirectToPage("Index") : Page();
        }

        public async Task Login(string name, string password)
        {
            if (name != string.Empty && password != string.Empty)
            {
                if (_context.Users.ToList().Count > 0)
                {
                    foreach (User user in _context.Users.ToList())
                    {
                        if (user.Name.ToLower() == name.ToLower() && user.Password == password)
                        {
                            ErrorMessage = string.Empty;
                            IsLoggedIn = true;

                            ChatModel.Username = user.Username;

                            //Authentication {
                                List<Claim> claims = new()
                                {
                                    new Claim(ClaimTypes.NameIdentifier, name),
                                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                                    new Claim(ClaimTypes.NameIdentifier, password)
                                };

                                ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                                AuthenticationProperties properties = new()
                                {
                                    AllowRefresh = true,
                                    IsPersistent = true
                                };

                                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                            //}

                            redirectToPage = true;
                            return;
                        }

                        ErrorMessage = "Cannot find a registered user with this name and password!";
                    }

                    redirectToPage = false;
                    return;
                }

                else
                {
                    ErrorMessage = "Cannot find a registered user!";

                    redirectToPage = false;
                    return;
                }
            }
        }
    }
}
