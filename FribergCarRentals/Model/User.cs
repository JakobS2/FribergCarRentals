using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
		[EmailAddress]
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
