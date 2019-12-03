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
    [Route("Clients")]
    public class ClientController : Controller
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [Route("Create/{name}/{surname}/{patronymic}/{phone}")]
        public async Task CreateClient([FromRoute]string name, [FromRoute]string surname, [FromRoute]string patronymic, [FromRoute]string phone)
        {
            await _clientService.CreateClient(name, surname, patronymic, phone);
        }

        [HttpPost]
        [Route("Update/{clientId}/{name}/{surname}/{patronymic}/{phone}")]
        public async Task UpdateClient([FromRoute]Guid clientId, [FromRoute]string name, [FromRoute]string surname, [FromRoute]string patronymic, [FromRoute]string phone)
        {
            await _clientService.UpdateClient(clientId, name, surname, patronymic, phone);
        }

        [HttpPost]
        [Route("Delete/{clientId}")]
        public async Task DeleteClient([FromRoute]Guid clientId)
        {
            await _clientService.DeleteClient(clientId);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetClients();
            return View("Index", new ClientsViewModel(clients));
        }
    }
}
