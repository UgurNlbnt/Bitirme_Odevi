using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.ViewModel.ViewModels.CarFeatureDetailViewModels
{
    public class ResultCarFeatureDetailViewModel
    {
        public int CarFeatureId { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public bool Avaiable { get; set; }
    }
}
