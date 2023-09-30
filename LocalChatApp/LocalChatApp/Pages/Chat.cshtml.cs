using LocalChatApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LocalChatApp.Pages
{
    public class ChatModel : PageModel
    {
        public List<Message>? Messages { get; private set; } = new List<Message>();

        readonly MyDBContext _context;

        public static string Username { get; set; } = string.Empty;

        public ChatModel(MyDBContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            ChangeUsername(Request.Query["username"].ToString());

            _ = AddUsernameAndMessageToDatabase(Username, Request.Query["message"].ToString());

            UpdateMessagesList();
        }

        private async Task AddUsernameAndMessageToDatabase(string username, string message)
        {
            if (username != string.Empty && message != string.Empty)
            {
                Message _message = new()
                {
                    UsernameAndMessage = username + ":" + message
                };
                await _context.Messages.AddAsync(_message);
                _context.SaveChanges();
            }
        }

        void UpdateMessagesList()
        {
            Messages = _context.Messages.ToList();
        }

        void ChangeUsername(string username)
        {
            if (username != string.Empty)
                foreach (User user in _context.Users.ToList())
                {
                    if (user.Username == Username)
                    {
                        user.Username = username;
                        _context.SaveChanges();
                        Username = username;
                    }   
                }
        }
    }
}
