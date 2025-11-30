using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.CarPricingQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.CarPricingResult;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.LocationResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Application.Interface.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.CarPricingHandler
{
    public class GetCarPricingsWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;
        public GetCarPricingsWithCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values =  _carPricingRepository.GetCarPricingsWithCars();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                
                Amount= x.Amount,
                CarPricingId= x.CarPricingId,
                Brand= x.Car.Brand.Name,
                Model= x.Car.Model,
                CoverImageUrl= x.Car.CoverImageUrl
            }).ToList();
        }
    }
}
