using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingİnterfaces;
using CarBook.Application.Interfaces.CarRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.Queries
{
	public class GetCarPricingWithBrandByPricingIdQueryHandler : IRequestHandler<GetCarPricingWithBrandByPricingIdQuery, List<GetCarPricingWithBrandByPricingIdQueryResult>>
	{
		private readonly ICarPricingRepository _carPricingRepository;

		public GetCarPricingWithBrandByPricingIdQueryHandler(ICarPricingRepository carPricingRepository)
		{
			_carPricingRepository = carPricingRepository;
		}

		public async Task<List<GetCarPricingWithBrandByPricingIdQueryResult>> Handle(GetCarPricingWithBrandByPricingIdQuery request, CancellationToken cancellationToken)
		{
			var values = _carPricingRepository.GetCarPricingWithCarByPricingId(request.PricingID);
			return values;
		}
	}
}
