using Microsoft.EntityFrameworkCore;

namespace LocalChatApp.Models
{
	public class MyDBContext : DbContext
	{
		public DbSet<Message> Messages { get; set; }

		public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
		{
		}
	}
}