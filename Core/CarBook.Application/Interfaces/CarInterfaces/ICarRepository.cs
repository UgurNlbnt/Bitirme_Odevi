using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarRepositories
{
    public interface ICarRepository
    {
        List<Car> GetCarWithBrand();
        List<Car> GetLast5CarsWithBrands();
        Car GetCarWithBrandByCarId(int id);

    }
}
