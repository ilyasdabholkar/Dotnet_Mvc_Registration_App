using RegisterModule.Models;

namespace RegisterModule.Interfaces
{
    public interface IUserService
    {
        public bool AddUser(User U);

        public User FindByEmail(string email);
    }
}
