using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRentals.Model
{
    public class Rental
    {
        public Rental()
        {
        }
        public int RentalId { get; set; }
        [Display(Name = "Start Date")]
		[Required]
		public DateTime StartDate { get; set; } = DateTime.Now.Date;
        [Display(Name = "End Date")]
		[Required]
		public DateTime EndDate { get; set; } = DateTime.Now.Date;
        [ForeignKey("Car")]
        public int CarId { get; set; }
		[Required]
		public Car Car { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
		[Required]
		public User User { get; set; }

    }
}
