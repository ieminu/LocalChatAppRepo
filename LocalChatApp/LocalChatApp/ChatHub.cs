using Microsoft.AspNetCore.SignalR;

namespace LocalChatApp
{
	public class ChatHub : Hub
	{
		public async Task SendMessage(string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", message);
		}
	}
}
