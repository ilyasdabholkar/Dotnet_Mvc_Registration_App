using Microsoft.EntityFrameworkCore;
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

            try
            {
                List<User> users = _dbContext.User.Include("Country").Include("State").Include("City")
                    .Include(x=>x.UserJobTypes).ThenInclude(x=>x.JobType).Where(i=>i.IsDeleted == false).ToList();
                return users;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<User>();
            }

        }
    }
}
