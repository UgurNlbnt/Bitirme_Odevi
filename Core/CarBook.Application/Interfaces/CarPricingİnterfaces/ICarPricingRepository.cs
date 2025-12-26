using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarPricingİnterfaces
{
    public interface ICarPricingRepository
    {
       List<CarPricing> GetCarPricingsWithCar();
       List<GetCarPricingWithTimePeriodQueryResult> GetCarPricingsWithTimePeriod();
       List<GetCarPricingWithBrandByPricingIdQueryResult> GetCarPricingWithCarByPricingId(int pricingId);
	}
}
