using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarRepositories;
using CarBook.Domain.Entities;
using CarBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Car> GetCarWithBrand()
        {
            var values = _context.Cars.Include(x =>x.Brand).ToList();
            return values;
        }

        public Car GetCarWithBrandByCarId(int id)
        {
            var value = _context.Cars.Include(x => x.Brand).Where(y => y.CarId == id).FirstOrDefault();
            return value!;
        }

        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).OrderByDescending(y => y.CarId).Take(5).ToList();
            return values;
        }

    }
}
