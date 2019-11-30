using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;

namespace TestHotel.ViewModels
{
    public class FilterViewModel
    {
        public SelectList Types { get; set; }
        public Guid? SelectedType { get; set; }
        public SelectList States { get; set; }
        public Guid? SelectedState { get; set; }
        public int? SelectedCapacity { get; set; }
        public string SelectedNumber { get; set; }

        public FilterViewModel(List<RoomType> types, Guid? selectedType, List<State> states, Guid? selectedState, string number, int? capacity)
        {
            States = new SelectList(states, "Id", "Name", selectedState);
            Types = new SelectList(types, "Id", "Type", selectedType);
            SelectedCapacity = capacity;
            SelectedNumber = number;
        }
    }
}
