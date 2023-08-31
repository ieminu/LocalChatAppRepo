using LocalChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LocalChatApp.Pages
{
    public class ChatModel : PageModel
    {
        public Message? Message { get; set; }

        public List<Message> Messages = new();

        readonly MyDBContext _context;

        public ChatModel(MyDBContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
			if (Request.Query["message"].ToString() != "")
			{
				Message message = new()
				{
					MessageProp = Request.Query["message"]
				};

				_context.Messages.Add(message);

				_context.SaveChanges();
			}

			Messages = _context.Messages.ToList();
        }
    }
}
