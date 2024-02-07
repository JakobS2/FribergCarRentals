using FribergCarRentals.Model;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals.Data
{
    public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Car> Cars { get; set; }
		public DbSet<Rental> Rentals { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
