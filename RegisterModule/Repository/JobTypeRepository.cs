using RegisterModule.Context;
using RegisterModule.Interfaces;
using RegisterModule.Models;

namespace RegisterModule.Repository
{
    public class JobTypeRepository : IJobTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public JobTypeRepository(ApplicationDbContext ctx)
        {
            this._dbContext = ctx;
        }

        public List<JobType> GetJobTypes()
        {
            return _dbContext.JobTypes.ToList();
        }
    }
}
