using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;

namespace TestHotel.ViewModels
{
    public class VisitsViewModel
    {
        public List<Visit> Visits { get; set; }

        public VisitsViewModel(List<Visit> visits)
        {
            Visits = visits;
        }
    }
}
