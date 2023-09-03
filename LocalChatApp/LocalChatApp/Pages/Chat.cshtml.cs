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
        }

        public void SaveAndShowMessage(string message)
        {
            if (message != "")
            {
                //Saving
                Message _message = new()
                {
                    MessageProp = message
                };
                _context.Messages.Add(_message);
                _context.SaveChanges();

                Messages = _context.Messages.ToList();
            }
        }
    }
}
