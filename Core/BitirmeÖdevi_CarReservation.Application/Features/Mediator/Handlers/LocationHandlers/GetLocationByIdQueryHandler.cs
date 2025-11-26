using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.LocationQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.LocationResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return new GetLocationByIdQueryResult
            {
                LocationId = value.LocationId,
                Name = value.Name
            };
        }
    }
}

