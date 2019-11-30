using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        
        public List<Visit> Visits { get; set; }
        
        public Client()
        {

        }

        public Client(string name, string surname, string patronymic, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Phone = phone;
        }
    }
}
