using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Queries.BrandQueries;
using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Queries.CarQueries;
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
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                BrandId = values.BrandId,
                BigImageUrl = values.BigImageUrl,
                CoverImageUrl = values.CoverImageUrl,
                Fuel = values.Fuel,
                CarId = values.CarId,
                Transmission = values.Transmission,
                Seat= values.Seat,
                Model = values.Model,
                Km = values.Km,
                Luggage = values.Luggage
            };
        }
    }
}
