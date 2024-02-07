using FribergCarRentals.Model;

namespace FribergCarRentals.Data
{
    public class CarRepository : ICar
	{
		private readonly ApplicationDbContext context;

		public CarRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public Car AddCar(Car car)
		{
			context.Cars.Add(car);
			return car;
		}

		public void DeleteCar(int id)
		{
			Car car = context.Cars.Find(id);
			context.Cars.Remove(car);
		}

		public IList<Car> GetAll()
		{
			return context.Cars.OrderBy(x => x.CarId).ToList();
		}

		public Car GetById(int id)
		{
			return context.Cars.FirstOrDefault(s => s.CarId == id);
		}

		public void EditCar(Car car)
		{
			context.Cars.Update(car);
		}
		public void Save()
		{
			context.SaveChanges();
		}

	}
}

