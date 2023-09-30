using LocalChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LocalChatApp.Pages
{
    public class RegisterModel : PageModel
    {
        public string ErrorMessage { get; private set; } = string.Empty;

        public string SuccessMessage { get; private set; } = string.Empty;

        readonly MyDBContext _context;

        public RegisterModel(MyDBContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            _context.Database.ExecuteSqlRaw("delete from Users");
        }

        public void OnPost(string name, string username, string password)
        {
            if (name != string.Empty && username != string.Empty && password != string.Empty)
            {
                bool isAdded = false;

                foreach (User user in _context.Users.ToList())
                {
                    if (user.Name == name)
                    {
                        isAdded = true;
                        ErrorMessage = "This name is taken!";
                    }
                }

                if (!isAdded)
                {
                    User user = new()
                    {
                        Name = name,
                        Username = username,
                        Password = password
                    };
                    _ = AddUserToDatabase(user);
                }
            }
        }

        private async Task AddUserToDatabase(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                _context.SaveChanges();

                SuccessMessage = "Registered successfully!";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
