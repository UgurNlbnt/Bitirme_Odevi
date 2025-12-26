using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.Queries
{
    public class GetLast5CarsWithBrandsQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetLast5CarsWithBrandsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public List<GetLast5CarsWithBrandsQueryResult> Handle()
        {
            var values = _carRepository.GetLast5CarsWithBrands();
            return values.Select(x => new GetLast5CarsWithBrandsQueryResult()
            {
                CarId = x.CarId,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name,
                BrandModel = x.Brand.Model,
                Km = x.Km,
                Transmission = x.Transmission,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Seat = x.Seat,
                Luggage = x.Luggage,
                BigImageUrl = x.BigImageUrl
            }).ToList();
        }
    }
}
