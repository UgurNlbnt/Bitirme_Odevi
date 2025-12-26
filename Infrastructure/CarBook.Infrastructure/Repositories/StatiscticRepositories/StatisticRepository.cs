using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Domain.Entities;
using CarBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatiscticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            return _context.Comments.Include(y => y.Blog).GroupBy(x => x.BlogId).OrderByDescending(g => g.Count()).Select(b => b.First().Blog.Title).FirstOrDefault()!;
        }

        public string GetBrandNameByMaxCar()
        {
            return _context.Cars.Include(x => x.Brand).GroupBy(x => x.BrandId).OrderByDescending(g => g.Count()).Select(y =>y.First().Brand.Name).FirstOrDefault()!;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            return _context.CarPricings.Include(x => x.Pricing).Where(y => y.Pricing.Name == "Günlük").Average(y => y.Amount);
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            return _context.CarPricings.Include(x => x.Pricing).Where(y => y.Pricing.Name == "Aylık").Average(y => y.Amount);
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            return _context.CarPricings.Include(x => x.Pricing).Where(y => y.Pricing.Name == "Haftalık").Average(y => y.Amount);
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            return _context.CarPricings.Include(x => x.Car).ThenInclude(b => b.Brand).Include(x => x.Pricing).Where(y => y.Pricing.Name == "Günlük").OrderByDescending(k => k.Amount).Select(x => x.Car.Brand.Name + " "+ x.Car.Brand.Model).FirstOrDefault()!;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            return _context.CarPricings.Include(x => x.Car).ThenInclude(b => b.Brand).Include(x => x.Pricing).Where(y => y.Pricing.Name == "Günlük").OrderBy(k => k.Amount).Select(x => x.Car.Brand.Name +" "+ x.Car.Brand.Model).FirstOrDefault()!;
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetCarCountByFuelElectric()
        {
            return _context.Cars.Where(x => x.Fuel == "Hibrit").Count();
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            return _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            return _context.Cars.Where(x => x.Km < 1000).Count();
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            return _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }

        public int GetAuthorCount()
        {
            return _context.Authors.Count();
        }

        public decimal GetAvgRentPriceForHourly()
        {
            return _context.CarPricings.Include(x => x.Pricing).Where(y => y.Pricing.Name == "Saatlik").Average(y => y.Amount);
        }

        public int GetTestimonialCount()
        {
            return _context.Testimonials.Count();
        }

        public int GetCarCountByKmBiggerThen30000()
        {
            return _context.Cars.Where(x => x.Km > 30000).Count();
        }

        public int GetLargeLuggageCarCount()
        {
            return _context.Cars.Where(x => x.Luggage> 2).Count();
        }

        public int GetFiveSeatCarCount()
        {
            return _context.Cars.Where(x => x.Seat == 5).Count();
        }
    }
}
