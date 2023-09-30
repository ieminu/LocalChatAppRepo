using LocalChatApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LocalChatApp.Pages
{
    public class ChatModel : PageModel
    {
        public List<Message>? Messages { get; private set; } = new List<Message>();

        readonly MyDBContext _context;

        public static string Username { get; private set; } = "";

        public ChatModel(MyDBContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            string username = Request.Query["username"].ToString();
            string message = Request.Query["message"].ToString();

            if (username != string.Empty && message != string.Empty)
                _ = AddMessageToDatabase(username + ":" + message);

            Messages = _context.Messages.ToList();
        }

        private async Task AddMessageToDatabase(string usrAndMsg)
        {
            Message _message = new()
            {
                UsernameAndMessage = usrAndMsg
            };
            await _context.Messages.AddAsync(_message);
            _context.SaveChanges();
        }

        public static void SetUsername(string username)
        {
            Username = username;
        }
    }
}
