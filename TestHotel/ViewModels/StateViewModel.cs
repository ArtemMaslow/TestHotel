using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;

namespace TestHotel.ViewModels
{
    public class StateViewModel
    {
        public State State { get; set; }

        public StateViewModel(State state)
        {
            State = state;
        }
    }
}
