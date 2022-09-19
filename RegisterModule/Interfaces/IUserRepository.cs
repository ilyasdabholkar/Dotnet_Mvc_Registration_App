using RegisterModule.Models;

namespace RegisterModule.Interfaces
{
    public interface IUserRepository
    {
        public bool addUser(User u);
        public List<User> GetAllUsers();
    }
}
