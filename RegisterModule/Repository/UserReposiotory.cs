using RegisterModule.Context;
using RegisterModule.Interfaces;
using RegisterModule.Models;

namespace RegisterModule.Repository
{
    public class UserReposiotory : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserReposiotory(ApplicationDbContext ctx)
        {
            this._dbContext = ctx;
        }

        public bool addUser(User u)
        {
            try
            {
                var added = _dbContext.User.Add(u);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {

            List<User> users = _dbContext.User.ToList();
            return users;
        }
    }
}
