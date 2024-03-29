﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("Rooms")]
    public class RoomController : Controller
    {
        private readonly RoomService _roomService;
        private readonly StateService _stateService;
        private readonly RoomTypeService _roomTypeService;

        public RoomController(RoomService roomService, StateService stateService, RoomTypeService roomTypeService)
        {
            _roomService = roomService;
            _stateService = stateService;
            _roomTypeService = roomTypeService;
        }

        [HttpPost]
        [Route("Create/{number}/{capacity}/{typeId}/{stateId}/{price}")]
        public async Task CreateRoom([FromRoute]string number, [FromRoute]int capacity, [FromRoute]Guid typeId, [FromRoute]Guid stateId, [FromRoute]decimal price)
        {
            await _roomService.CreateRoom(number, capacity, typeId, stateId, price);
        }

        [HttpPost]
        [Route("Update/{roomId}/{number}/{capacity}/{typeId}/{stateId}/{price}")]
        public async Task UpdateRoom([FromRoute]Guid roomId, [FromRoute]string number, [FromRoute]int capacity, [FromRoute]Guid typeId, [FromRoute]Guid stateId, [FromRoute]decimal price)
        {
            await _roomService.UpdateRoom(roomId, number, capacity, typeId, stateId, price);
        }

        [HttpPost]
        [Route("Delete/{roomId}")]
        public async Task DeleteRoom([FromRoute]Guid roomId)
        {
            await _roomService.DeleteRoom(roomId);
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]Guid? typeId, [FromQuery]Guid? stateId, [FromQuery]int? capacity, [FromQuery]string number, [FromQuery]int page = 1, [FromQuery]SortState sortOrder = SortState.NumberAsc)
        {
            int pageSize = 20;

            var rooms = await _roomService.GetRooms();

            //Filter
            if (typeId != null)
            {
                rooms = rooms.Where(t => t.TypeId == typeId).ToList();
            }
            if (capacity != null)
            {
                if (capacity == 0)
                {
                    rooms = rooms.Where(c => c.Capacity >= capacity).ToList();
                }
                else
                {
                    rooms = rooms.Where(c => c.Capacity == capacity).ToList();
                }
            }
            if (stateId != null)
            {
                rooms = rooms.Where(s => s.StateId == stateId).ToList();
            }
            if (!String.IsNullOrEmpty(number))
            {
                rooms = rooms.Where(n => n.Number.Equals(number)).ToList();
            }

            //Sort
            switch (sortOrder)
            {
                case SortState.NumberAsc:
                    rooms = rooms.OrderBy(r => r.Number).ToList();
                    break;
                case SortState.NumberDesc:
                    rooms = rooms.OrderByDescending(r => r.Number).ToList();
                    break;
                case SortState.TypeAsc:
                    rooms = rooms.OrderBy(r => r.TypeId).ToList();
                    break;
                case SortState.TypeDesc:
                    rooms = rooms.OrderByDescending(r => r.TypeId).ToList();
                    break;
                case SortState.StateAsc:
                    rooms = rooms.OrderBy(r => r.StateId).ToList();
                    break;
                case SortState.StateDesc:
                    rooms = rooms.OrderByDescending(r => r.StateId).ToList();
                    break;
                case SortState.CapacityAsc:
                    rooms = rooms.OrderBy(r => r.Capacity).ToList();
                    break;
                case SortState.CapacityDesc:
                    rooms = rooms.OrderByDescending(r => r.Capacity).ToList();
                    break;
            }

            //Paging
            var count = rooms.Count();
            var viewRooms = rooms.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var states = await _stateService.GetStates();
            var types = await _roomTypeService.GetRoomTypes();

            RoomViewModel viewModel = new RoomViewModel
            {
                FilterViewModel = new FilterViewModel(types, typeId, states, stateId, number, capacity),
                SortViewModel = new SortViewModel(sortOrder),
                PageViewModel = new PageViewModel(count, page, pageSize),
                Rooms = viewRooms
            };

            return View("Index", viewModel);
        }

    }
}
