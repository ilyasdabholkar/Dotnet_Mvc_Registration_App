using RegisterModule.Models;

namespace RegisterModule.Interfaces
{
    public interface IJobTypeService
    {
        public List<JobType> GetJobTypes();
    }
}
