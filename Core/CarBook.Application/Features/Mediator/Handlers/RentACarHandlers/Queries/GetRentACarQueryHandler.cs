using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers.Queries
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationID && x.Available == true);
            return values.Select(x => new GetRentACarQueryResult()
            {
                CarID = x.CarId,
                CarBrand = x.Car.Brand.Name,
                CarModel = x.Car.Brand.Model,
                CoverImageUrl = x.Car.BigImageUrl,
                PricingAmount = x.Car.CarPricings.Where(at=> at.CarId == x.CarId).Select(y =>y.Amount).FirstOrDefault(),
                PricingName = x.Car.CarPricings.Where(bp => bp.CarId == x.CarId).Select(y => y.Pricing.Name).FirstOrDefault()!
            }).ToList();
        }
    }
}
