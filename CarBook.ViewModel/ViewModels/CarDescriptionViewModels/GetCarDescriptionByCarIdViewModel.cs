using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.ViewModel.ViewModels.CarDescriptionViewModels
{
	public class GetCarDescriptionByCarIdViewModel
	{
		public int CarDescriptionId { get; set; }
		public int CarId { get; set; }
		public string Details { get; set; }
	}
}
