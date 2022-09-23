using RegisterModule.Context;
using RegisterModule.Interfaces;
using RegisterModule.Models;

namespace RegisterModule.Repository
{
    public class UserJobTypeRepository : IUserJobTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserJobTypeRepository(ApplicationDbContext ctx)
        {
            this._dbContext = ctx;
        }

        public bool AddUserJobTypes(List<UserJobType> userJobTypes)
        {
            try
            {
                _dbContext.UserJobType.AddRange(userJobTypes);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
