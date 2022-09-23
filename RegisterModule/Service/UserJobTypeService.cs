using RegisterModule.Interfaces;
using RegisterModule.Models;

namespace RegisterModule.Service
{
    public class UserJobTypeService : IUserJobTypeService
    {

        private readonly IUserJobTypeRepository _userJobTypeRepository;

        public UserJobTypeService(IUserJobTypeRepository userJobTypeRepository)
        {
            _userJobTypeRepository = userJobTypeRepository;
        }

        public bool AddUserJobTypes(int[] jobTypes, int userId)
        {
            try
            {
                List<UserJobType> userJobTypes = new List<UserJobType>();
                foreach (int i in jobTypes)
                {
                    userJobTypes.Add(new UserJobType { JobId = i , UserId = userId});
                }
                _userJobTypeRepository.AddUserJobTypes(userJobTypes);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
