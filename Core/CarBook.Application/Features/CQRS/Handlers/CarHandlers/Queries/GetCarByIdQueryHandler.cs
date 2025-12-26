using CarBook.Application.Features.CQRS.Queries.CarQueries;
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
    public class GetCarByIdQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarByIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle( GetCarByIdQuery request)
        {
            var value =  _repository.GetCarWithBrandByCarId(request.Id);
            return new GetCarByIdQueryResult()
            {
                CarId = value.CarId,
                BrandId = value.BrandId,
                BigImageUrl = value.BigImageUrl,
                Km = value.Km,
                CoverImageUrl = value.CoverImageUrl,
                Transmission = value.Transmission,
                Fuel = value.Fuel,
                Seat = value.Seat,
                Luggage = value.Luggage,
                BrandName = value.Brand.Name,
                BrandModel = value.Brand.Model
            };
        }
    }
}
