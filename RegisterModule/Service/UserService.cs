using RegisterModule.Interfaces;
using RegisterModule.Models;

namespace RegisterModule.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public bool AddUser(User U)
        {
            _userRepository.addUser(U);
            return true;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User FindByEmail(string email)
        {
            return _userRepository.GetAllUsers().FirstOrDefault(u => u.Email == email);
        }

        public User FindByAlternateEmail(string email)
        {
            return _userRepository.GetAllUsers().FirstOrDefault(u => u.AlternateEmail == email);
        }

        public User FindByMobile(string mobile)
        {
            return _userRepository.GetAllUsers().FirstOrDefault(u => u.MobileNo == mobile);
        }
    }
}
