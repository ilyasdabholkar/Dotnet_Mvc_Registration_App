using RegisterModule.Models;

namespace RegisterModule.Interfaces
{
    public interface IStateService
    {
        public List<State> GetStates(int countryId);
    }
}
