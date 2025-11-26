using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Results.BrandResult;
using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Results.CarResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(b => new GetCarQueryResult
            {
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
