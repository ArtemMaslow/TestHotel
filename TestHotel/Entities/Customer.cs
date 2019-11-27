using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Entities
{
    public class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }

        public Customer()
        {

        }

        public Customer(string name, string surname, string patronymic, string phone)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Phone = phone;
        }
    }
}
