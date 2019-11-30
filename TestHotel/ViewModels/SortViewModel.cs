using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;

namespace TestHotel.ViewModels
{
    public class SortViewModel
    {
        public SortState NumberSort { get; private set; }
        public SortState TypeSort { get; private set; }
        public SortState CapacitySort { get; private set; }
        public SortState StateSort { get; private set; }
        public SortState Current { get; private set; }
        public SortViewModel(SortState sortOrder)
        {
            NumberSort = sortOrder == SortState.NumberAsc ? SortState.NumberDesc : SortState.NumberAsc;
            TypeSort = sortOrder == SortState.TypeAsc ? SortState.TypeDesc : SortState.TypeAsc;
            CapacitySort = sortOrder == SortState.StateAsc ? SortState.StateDesc : SortState.StateAsc;
            StateSort = sortOrder == SortState.CapacityAsc ? SortState.CapacityDesc : SortState.CapacityAsc;
            
            Current = sortOrder;
        }
    }
}
