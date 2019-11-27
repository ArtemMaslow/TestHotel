using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Entities;
using TestHotel.Services;

namespace TestHotel.Controllers
{
    [Route("Room")]
    public class RoomController : ControllerBase
    {

        private readonly RoomService _roomService;

        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Route("{number}")]
        public async Task<Room> GetRoomInfo([FromRoute]string number)
        {
            return await _roomService.GetRoomInfo(number);
        }

        [HttpPost]
        [Route("crroom")]
        public async Task CreateRoom([FromRoute]string number, [FromRoute]int capacity, [FromRoute]string type, [FromRoute]bool state)
        {
            await _roomService.Room(number, capacity, type, state);
        }
    }
}
