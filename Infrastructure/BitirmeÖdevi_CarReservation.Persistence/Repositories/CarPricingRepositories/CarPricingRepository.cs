using BitirmeÖdevi_CarReservation.Application.Interface.CarInterfaces;
using BitirmeÖdevi_CarReservation.Application.Interface.CarPricingInterfaces;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using BitirmeÖdevi_CarReservation.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        public readonly CarBookContext _context;
        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }
        public List<CarPricing> GetCarPricingsWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(c => c.Brand).Include(p => p.Pricing).Where(y=>y.PricingId==2).ToList();
            return values;
        }
    }
}
