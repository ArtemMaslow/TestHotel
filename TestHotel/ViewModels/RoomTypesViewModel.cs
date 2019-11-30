using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;

namespace TestHotel.ViewModels
{
    public class RoomTypesViewModel
    {
        public List<RoomType> RoomTypes { get; set; }

        public RoomTypesViewModel(List<RoomType> roomTypes)
        {
            RoomTypes = roomTypes;
        }
    }
}
