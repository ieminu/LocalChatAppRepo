using LocalChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LocalChatApp.Pages
{
    public class RegisterModel : PageModel
    {
        readonly MyDBContext _context;

        public string ReportMessage { get; private set; } = "";

        public RegisterModel(MyDBContext context)
        {
            _context = context;
        }

        public void OnPost(string username, string password)
        {
            bool isAdded = false;

            foreach (User user in _context.Users.ToList())
            {
                if (user.Username == username)
                {
                    isAdded = true;
                }
            }

            if (!isAdded)
            {
                User user = new User 
                {
                    Username = username,
                    Password = password
                };
                _ = AddUserToDatabase(user);
            }
        }

        private async Task AddUserToDatabase(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                _context.SaveChanges();

                ReportMessage = "Registered successfully!";
            }
            catch (Exception ex)
            {
                ReportMessage = ex.Message;
            }
        }
    }
}
