using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.ViewModel.ViewModels.CarPricingViewModels
{
	public class ResuıltCarPricingWithTimePeriodAndBrandViewModel
	{
			public string brandName { get; set; }
			public string brandModel { get; set; }
			public decimal hourlyAmount { get; set; }
			public decimal dailyAmount { get; set; }
			public decimal weeklyAmount { get; set; }
			public decimal monthlyAmount { get; set; }
			public string coverImageUrl { get; set; }
	}
}
