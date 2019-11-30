using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;

namespace TestHotel.ViewModels
{
    public class ClientsViewModel
    {
        public List<Client> Clients { get; set; }
        public ClientsViewModel(List<Client> clients)
        {
            Clients = clients;
        }
    }
}
