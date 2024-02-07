using FribergCarRentals.Model;

namespace FribergCarRentals.Data
{
    public interface ICar
	{
		Car GetById(int id);
        IList<Car> GetAll();
		Car AddCar(Car car);
		void DeleteCar(int id);
		void Save();
		void EditCar(Car car);
	}
}
