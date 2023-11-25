using Microsoft.EntityFrameworkCore;

namespace LocalChatApp.Models
{
	public class MyDBContext : DbContext
	{
        #region Public Variables

        public DbSet<Message> Messages { get; set; }

		public DbSet<User> Users { get; set; }

        #endregion

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
		{
		}
    }
}