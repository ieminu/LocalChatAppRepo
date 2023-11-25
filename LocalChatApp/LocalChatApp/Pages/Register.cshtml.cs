using LocalChatApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Security.Claims;

namespace LocalChatApp.Pages
{
    public class RegisterModel : PageModel
    {
        public string ErrorMessage { get; private set; } = string.Empty;

        public string SuccessMessage { get; private set; } = string.Empty;

        [BindProperty]
        public new User User { get; set; } = new User
        {
            Name = string.Empty,
            Username = string.Empty,
            Password = string.Empty
        };

        [BindProperty]
        public bool WantToLogin { get; set; } = false;

        private readonly MyDBContext _context;

        public static List<User> Users { get; private set; } = new();

        public RegisterModel(MyDBContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            Register(User);

            if (WantToLogin)
            {
                return RedirectToPage("Login", new {User?.Name, User?.Password});
            }

            else
                return Page();
        }

        void Register(User user)
        {
            if (user.Name != string.Empty && user.Username != string.Empty && user.Password != string.Empty)
            {
                bool isAdded = false;

                foreach (User _user in _context.Users.ToList())
                {
                    if (_user.Name == user.Name)
                    {
                        isAdded = true;
                        ErrorMessage = "This name is taken!";
                    }
                }

                if (!isAdded)
                {
                    _ = AddUserToDatabase(user);
                }
            }
        }

        private async Task AddUserToDatabase(User user)
        {
            if (_context != null)
            {
                try
                {
                    await _context.Users.AddAsync(user);
                    _context.SaveChanges();

                    Users.Add(user);

                    SuccessMessage = "Registered successfully!";
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
        }

        public static void SetUsers(MyDBContext context)
        {
            Users = context.Users.ToList();
        }
    }
}
