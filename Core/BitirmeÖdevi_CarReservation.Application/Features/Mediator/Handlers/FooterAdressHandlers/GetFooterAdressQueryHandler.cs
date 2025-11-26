using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.FooterAdressQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.FooterAdressResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class GetFooterAdressQueryHandler : IRequestHandler<GetFooterAdressQuery, List<GetFooterAdressQueryResult>>
    {
        private readonly IRepository<FooterAdress> _repository;

        public GetFooterAdressQueryHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAdressQueryResult>> Handle(GetFooterAdressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetFooterAdressQueryResult
            {
                FooterAdressId = x.FooterAdressId,
                Description = x.Description,
                Adress = x.Adress,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email
            }).ToList();
        }
    }
}
