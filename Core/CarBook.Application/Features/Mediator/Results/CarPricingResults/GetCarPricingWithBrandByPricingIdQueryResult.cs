using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarPricingResults
{
	public class GetCarPricingWithBrandByPricingIdQueryResult
	{
		public int CarPricingId { get; set; }
		public int CarId { get; set; }
		public string CarBrand { get; set; }
		public string CarModel { get; set; }
		public decimal PricingAmount { get; set; }
		public string PricingName { get; set; }
		public string CoverImageUrl { get; set; }
	}
}
