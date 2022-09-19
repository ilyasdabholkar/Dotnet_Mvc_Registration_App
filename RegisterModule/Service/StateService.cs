using RegisterModule.Interfaces;
using RegisterModule.Models;

namespace RegisterModule.Service
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            this._stateRepository = stateRepository;
        }

        public List<State> GetStates(int countryId)
        {
            Console.WriteLine($"CId Service : {countryId}");
            List<State> states = _stateRepository.GetStates(countryId);
            return states;
        }
    }
}
