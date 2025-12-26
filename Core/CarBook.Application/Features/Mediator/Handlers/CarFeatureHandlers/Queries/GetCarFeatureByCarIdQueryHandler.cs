using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers.Queries
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var value = _carFeatureRepository.GetCarFeatureWithFeatureAndCarByCarId(request.Id);
            return value.Select(x => new GetCarFeatureByCarIdQueryResult()
            {
                Avaiable = x.Avaiable,
                FeatureName = x.Feature.Name,
                CarModel = x.Car.Brand.Model,
                CarName = x.Car.Brand.Name,
                CarFeatureId = x.CarFeatureId,
                FeatureID = x.FeatureID,
                CarID = x.CarId
            }).ToList();
        }
    }
}
