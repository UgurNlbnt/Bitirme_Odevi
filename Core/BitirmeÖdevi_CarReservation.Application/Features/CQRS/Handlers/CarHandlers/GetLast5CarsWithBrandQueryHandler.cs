using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Results.CarResults;
using BitirmeÖdevi_CarReservation.Application.Interface.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _repository.GetLast5CarsWithBrands();
            return values.Select(b => new GetCarWithBrandQueryResult
            {
                BrandName = b.Brand.Name,
                BrandId = b.BrandId,
                BigImageUrl = b.BigImageUrl,
                CarId = b.CarId,
                CoverImageUrl = b.CoverImageUrl,
                Fuel = b.Fuel,
                Km = b.Km,
                Luggage = b.Luggage,
                Model = b.Model,
                Seat = b.Seat,
                Transmission = b.Transmission
            }).ToList();
        }
    }
}
