using DataLayer.Entities;

namespace DataLayer.Repositories {
	public class UserRepository : RepositoryBase<User> {
		public UserRepository(AppDbContext dbContext) : base(dbContext) {
		}

		public User GetByEmail(string email) {
			return _dbContext.Users.FirstOrDefault(u => u.Email == email);
		}
	}
}