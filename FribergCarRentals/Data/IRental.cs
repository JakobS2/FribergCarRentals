using FribergCarRentals.Model;

namespace FribergCarRentals.Data
{
    public interface IRental
    {
        Rental GetById(int Id);
        IList<Rental> GetAll();
        IList<Rental> GetAllByUserId(int userId);
        Rental AddRental(Rental rental);
        void DeleteRental(int id);
        void Save();
        void EditRental(Rental rental);
    }
}
