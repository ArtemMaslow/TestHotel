using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestHotel.Services;
using TestHotel.ViewModels;

namespace TestHotel.Controllers
{
    [Route("State")]
    public class StateController : Controller
    {
        private readonly StateService _stateService;

        public StateController(StateService stateService)
        {
            _stateService = stateService;
        }

        [HttpPost]
        [Route("Create/{state}")]
        public async Task CreateState([FromRoute]string state)
        {
            await _stateService.CreateState(state);
        }

        [HttpPost]
        [Route("Update/{stateId}/{state}")]
        public async Task UpdateState([FromRoute]Guid stateId, [FromRoute]string state)
        {
            await _stateService.UpdateState(stateId, state);
        }

        [HttpPost]
        [Route("Delete/{stateId}")]
        public async Task DeleteState([FromRoute]Guid stateId)
        {
            await _stateService.DeleteState(stateId);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var states = await _stateService.GetStates();
            return View("Index", new StatesViewModel(states));
        }

        //[HttpGet]
        //[Route("State/GetState/{id}")]
        //public async Task<IActionResult> Index([FromRoute]Guid id)
        //{
        //    var state = await _stateService.GetState(id);
        //    return View("Index", new StateViewModel(state));
        //}
    }
}
