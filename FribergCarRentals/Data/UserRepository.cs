using FribergCarRentals.Model;

namespace FribergCarRentals.Data
{
    public class UserRepository : IUser
	{
		private readonly ApplicationDbContext context;

		public UserRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public User AddUser(User user)
		{
			context.Users.Add(user);
			return user;
		}

		public void DeleteUser(int id)
		{
			User user = context.Users.Find(id);
			context.Users.Remove(user);
		}

		public void EditUser(User user)
		{
			context.Users.Update(user);
		}

		public IList<User> GetAll()
		{
			return context.Users.OrderBy(x => x.Name).ToList();
		}

		public User GetById(int id)
		{
			return context.Users.FirstOrDefault(s => s.UserId == id);
		}

		public User GetByEmail(string email)
		{
			return context.Users.FirstOrDefault(s => s.Email == email);
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}
