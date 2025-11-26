using BitirmeÖdevi_CarReservation.Application.Interface.CarInterfaces;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using BitirmeÖdevi_CarReservation.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;
        
        public CarRepository(CarBookContext context)
        {
            _context = context;
        }
        public List<Car> GetCarsListWithBrands()
        {
            var values = _context.Cars.Include(c => c.Brand).ToList();
            return values;
        }

        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _context.Cars.Include(c => c.Brand).OrderByDescending(c => c.CarId).Take(5).ToList();
            return values;
        }
    }
}
