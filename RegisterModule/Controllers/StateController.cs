using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegisterModule.Interfaces;
using RegisterModule.Models;

namespace RegisterModule.Controllers
{
    public class StateController : Controller
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            this._stateService = stateService;
        }

        [HttpPost]
        public JsonResult GetStates(int id)
        {
            List<State> states = _stateService.GetStates(id);
            List<SelectListItem> stateList = (from state in states
                                              select new SelectListItem
                                              {
                                                  Value = state.StateId.ToString(),
                                                  Text = state.StateName.ToString()
                                              }).ToList();
            return Json(stateList);
        }

    }
}
