using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals.Model
{
    public class Car
    {
        public Car()
        {
        }
        public int CarId { get; set; }
		[Required]
		public string Make { get; set; }
		[Required]
		public string Model { get; set; }
		[Required]
		public int Year { get; set; }
        [Required]
        public string? Image { get; set; }
		[Required]
		public int Price { get; set; }

    }
}
