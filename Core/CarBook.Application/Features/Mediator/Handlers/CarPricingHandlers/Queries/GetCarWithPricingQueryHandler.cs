using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingİnterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.Queries
{
    public class GetCarWithPricingQueryHandler : IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarWithPricingQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            var values = _carPricingRepository.GetCarPricingsWithCar(); 
            return values.Select(x => new GetCarPricingQueryResult()
            {
                CarPricingId = x.CarPricingId,
                CarBrand = x.Car.Brand.Name,
                CarModel = x.Car.Brand.Model,
                PricingAmount = x.Amount,
                PricingName = x.Pricing.Name,
                CoverImageUrl = x.Car.BigImageUrl,
				CarId = x.CarId
			}).ToList();
        }
    }
}
