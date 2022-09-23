using RegisterModule.Models;

namespace RegisterModule.Interfaces
{
    public interface IUserJobTypeRepository
    {
        public bool AddUserJobTypes(List<UserJobType> userJobTypes);
    }
}
