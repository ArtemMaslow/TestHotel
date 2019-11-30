using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;

namespace TestHotel.ViewModels
{
    public class StatesViewModel
    {
        public List<State> States { get; set; }

        public StatesViewModel(List<State> states)
        {
            States = states;
        }
    }
}
