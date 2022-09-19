using RegisterModule.Models;

namespace RegisterModule.Interfaces
{
    public interface IStateRepository
    {
        public List<State> GetStates(int countryId);
    }
}
