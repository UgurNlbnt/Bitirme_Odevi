using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.ViewModel.ViewModels.RentACarListViewModels
{
    public class RentACarRequestViewModel
    {
        public int LocationId { get; set; }
        public string PickUpDate { get; set; }
        public string DropOffDate { get; set; }
        public string PickUpTime { get; set; }
        public string DropOffTime { get; set; }
    }
}
