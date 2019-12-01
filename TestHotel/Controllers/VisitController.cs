using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;
using TestHotel.Services;
using TestHotel.ViewModels;

namespace TestHotel.Controllers
{
    [Route("Visit")]
    public class VisitController : Controller
    {
        private readonly VisitService _visitService;
        private readonly RoomService _roomService;
        private readonly ClientService _clientService;
        public VisitController(VisitService visitService, RoomService roomService, ClientService clientService)
        {
            _visitService = visitService;
            _roomService = roomService;
            _clientService = clientService;
        }

        [HttpPost]
        [Route("Create/{clientId}/{roomId}/{arrive}/{leave}/{stateId}")]
        public async Task CreateVisit([FromRoute]Guid clientId, [FromRoute]Guid roomId, [FromRoute]DateTime arrive, [FromRoute]DateTime leave, [FromRoute]Guid stateId)
        {
            await _visitService.CreateVisit(clientId, roomId, arrive, leave, stateId);
        }

        [HttpPost]
        [Route("Close/{visitId}/{stateId}")]
        public async Task CloseVisit([FromRoute]Guid visitId, [FromRoute]Guid stateId)
        {
            var visit = await _visitService.GetVisit(visitId);
            decimal cost;
            
            var days = visit.Leave - visit.Arrive;
            int day = 1;
            if (days.Days >= 1)
            {
                day = days.Days;
            }
            cost = visit.Room.Price * day;

            await _visitService.CloseVisit(visitId, cost, stateId);
        }

        [HttpPost]
        [Route("Update/{visitId}/{clientId}/{roomId}/{arrive}/{leave}")]
        public async Task UpdateVisit([FromRoute]Guid visitId, [FromRoute]Guid clientId, [FromRoute]Guid roomId, [FromRoute]DateTime arrive, [FromRoute]DateTime leave)
        {
            await _visitService.UpdateVisit(visitId, clientId, roomId, arrive, leave);
        }

        [HttpPost]
        [Route("Delete/{visitId}")]
        public async Task DeleteVisit([FromRoute]Guid visitId)
        {
            await _visitService.DeleteVisit(visitId);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var visits = await _visitService.GetVisits();
            return View("Index", new VisitsViewModel(visits));
        }
    }
}
