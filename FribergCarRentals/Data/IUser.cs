using FribergCarRentals.Model;

namespace FribergCarRentals.Data
{
    public interface IUser
	{
		User GetById(int id);
		User GetByEmail(string email);
        IList<User> GetAll();
		User AddUser(User user);
		void DeleteUser(int id);
		void Save();
		void EditUser(User user);
	}
}
