using RegisterModule.Models;

namespace RegisterModule.Interfaces
{
    public interface IJobTypeRepository
    {
        public List<JobType> GetJobTypes();
    }
}
