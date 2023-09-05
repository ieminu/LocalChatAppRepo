using LocalChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LocalChatApp.Pages
{
    public class ChatModel : PageModel
    {
        public List<Message>? Messages { get; private set; } = new List<Message>();

        readonly MyDBContext _context;

        public ChatModel(MyDBContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            if (Request.Query["message"].ToString() != "")
                _ = AddMessageToDatabase(Request.Query["message"].ToString());

            Messages = _context.Messages.ToList();
        }

        public async Task AddMessageToDatabase(string message)
        {
            Message _message = new()
            {
                MessageProp = message
            };
            await _context.Messages.AddAsync(_message);
            _context.SaveChanges();
        }
    }
}
