using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Services;
using TestHotel.ViewModels;

namespace TestHotel.Controllers
{
    [Route("RoomTypes")]
    public class RoomTypeController : Controller
    {
        private readonly RoomTypeService _roomTypeService;

        public RoomTypeController(RoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpPost]
        [Route("Create/{roomType}")]
        public async Task CreateState([FromRoute]string roomType)
        {
            await _roomTypeService.CreateRoomType(roomType);
        }

        [HttpPost]
        [Route("Update/{roomTypeId}/{roomType}")]
        public async Task UpdateState([FromRoute]Guid roomTypeId, [FromRoute]string roomType)
        {
            await _roomTypeService.UpdateRoomType(roomTypeId, roomType);
        }

        [HttpPost]
        [Route("Delete/{roomTypeId}")]
        public async Task DeleteState([FromRoute]Guid roomTypeId)
        {
            await _roomTypeService.DeleteRoomType(roomTypeId);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roomTypes = await _roomTypeService.GetRoomTypes();
            return View("Index", new RoomTypesViewModel(roomTypes));
        }
    }
}
