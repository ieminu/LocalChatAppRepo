using System.ComponentModel.DataAnnotations;

namespace LocalChatApp.Models
{
    public class User
    {
        #region Public Variables

        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }

        #endregion
    }
}
