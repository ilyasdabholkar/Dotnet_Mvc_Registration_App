using RegisterModule.Models;

namespace RegisterModule.Interfaces
{
    public interface IUserService
    {
        public bool AddUser(User U);
        public List<User> GetAllUsers();
        public User FindByEmail(string email);
        public User FindByAlternateEmail(string email);
        public User FindByMobile(string mobile);
    }
}
