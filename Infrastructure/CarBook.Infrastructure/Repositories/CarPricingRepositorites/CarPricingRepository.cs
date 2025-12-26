using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingİnterfaces;
using CarBook.Domain.Entities;
using CarBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositorites
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingsWithCar()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).ToList();
            return values;
        }

        public List<GetCarPricingWithTimePeriodQueryResult> GetCarPricingsWithTimePeriod()
        {
            var values = _context.Cars
                .Include(x => x.Brand)
                .Include(y => y.CarPricings)
                .ThenInclude(d => d.Pricing)
                .Select(x => new GetCarPricingWithTimePeriodQueryResult
                {
                    CarId = x.CarId,
                    CoverImageUrl = x.BigImageUrl,
                    BrandName = x.Brand.Name,
                    BrandModel = x.Brand.Model,
                    HourlyAmount = x.CarPricings.Where(x => x.Pricing.Name == "Saatlik").Select(y => y.Amount).FirstOrDefault(),
                    DailyAmount = x.CarPricings.Where(x => x.Pricing.Name == "Günlük").Select(y => y.Amount).FirstOrDefault(),
                    WeeklyAmount = x.CarPricings.Where(x => x.Pricing.Name == "Haftalık").Select(y => y.Amount).FirstOrDefault(),
                    MonthlyAmount = x.CarPricings.Where(x => x.Pricing.Name == "Aylık").Select(y => y.Amount).FirstOrDefault(),
                })
                .ToList();
            return values;
        }

        public List<GetCarPricingWithBrandByPricingIdQueryResult> GetCarPricingWithCarByPricingId(int pricingId)
        {
            var values = _context.CarPricings
                .Include(x => x.Car)
                .ThenInclude(y => y.Brand)
                .Include(z => z.Pricing)
                .Where(y => y.PricingId == pricingId)
                .ToList();
            return values.Select(y => new GetCarPricingWithBrandByPricingIdQueryResult
            {
                CarPricingId = y.CarPricingId,
                CarId = y.CarId,
                CarBrand = y.Car.Brand.Name,
                CarModel = y.Car.Brand.Model,
                PricingAmount = y.Amount,
                PricingName = y.Pricing.Name,
                CoverImageUrl = y.Car.BigImageUrl,
            }).ToList();
        }
    }
}
