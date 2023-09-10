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
            Messages = _context.Messages.ToList();

            if (Request.Query["message"].ToString() != "")
                _ = AddMessageToDatabase(Request.Query["username"].ToString() + ":" + Request.Query["message"].ToString());
        }

        public async Task AddMessageToDatabase(string unAndMsg)
        {
            Message _message = new()
            {
                MessageProp = unAndMsg
            };
            await _context.Messages.AddAsync(_message);
            _context.SaveChanges();
        }
    }
}
