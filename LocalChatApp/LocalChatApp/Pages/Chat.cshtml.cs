using LocalChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LocalChatApp.Pages
{
    //learn how to reset database *

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
            if (Request.Query["message"] != "")
			{
				Message message = new()
				{
					MessageProp = Request.Query["message"]
				};

				_context.Messages.Add(message);

				_context.SaveChanges();

				Messages = _context.Messages.ToList();
			}
        }
    }
}
