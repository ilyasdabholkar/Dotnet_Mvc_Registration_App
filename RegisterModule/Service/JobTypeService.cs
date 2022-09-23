using RegisterModule.Interfaces;
using RegisterModule.Models;

namespace RegisterModule.Service
{
    public class JobTypeService : IJobTypeService
    {
        private readonly IJobTypeRepository _jobTypeReposiotry;

        public JobTypeService(IJobTypeRepository repeo)
        {
            this._jobTypeReposiotry = repeo;
        }

        public List<JobType> GetJobTypes()
        {
            return _jobTypeReposiotry.GetJobTypes();
        }
    }

}
