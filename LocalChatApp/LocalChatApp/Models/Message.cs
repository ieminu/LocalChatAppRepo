using Microsoft.EntityFrameworkCore;

namespace LocalChatApp.Models
{
	public class Message
	{
        public int Id { get; set; }

        public string? MessageProp { get; set; }
    }
}
