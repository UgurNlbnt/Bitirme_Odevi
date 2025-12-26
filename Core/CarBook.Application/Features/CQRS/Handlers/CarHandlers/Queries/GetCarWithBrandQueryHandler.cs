using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarRepositories;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.Queries
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _carRepository.GetCarWithBrand();
            return  values.Select(x => new GetCarWithBrandQueryResult()
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
