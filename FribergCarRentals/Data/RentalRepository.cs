using FribergCarRentals.Model;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentals.Data
{
    public class RentalRepository : IRental
	{
		private readonly ApplicationDbContext context;

		public RentalRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public Rental AddRental(Rental rental)
		{
			context.Rentals.Add(rental);
			return rental;
		}

		public void DeleteRental(int id)
		{
			Rental rental = context.Rentals.Find(id);
			context.Rentals.Remove(rental);
		}

		public void EditRental(Rental rental)
		{
			context.Rentals.Update(rental);
		}

		public IList<Rental> GetAll()
		{
			return context.Rentals.OrderBy(r => r.StartDate).Include(r => r.Car).Include(r => r.User).ToList();
		}

        public IList<Rental> GetAllByUserId(int userId)
        {
            return context.Rentals.Where(r => r.UserId == userId).OrderBy(r => r.StartDate).Include(r => r.Car).Include(r => r.User).ToList();
        }

        public Rental GetById(int Id)
		{
			return context.Rentals.Include(r => r.Car).Include(r => r.User).FirstOrDefault(r => r.RentalId == Id);
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}

