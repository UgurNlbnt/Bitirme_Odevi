using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.FooterAdressQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.FooterAdressResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public  class GetFooterAdressByIdQueryHandler : IRequestHandler<GetFooterAdressByIdQuery, GetFooterAdressByIdQueryResult>
    {
        private readonly IRepository<FooterAdress> _repository;
        public GetFooterAdressByIdQueryHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAdressByIdQueryResult> Handle(GetFooterAdressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFooterAdressByIdQueryResult
            {
                FooterAdressId = value.FooterAdressId,
                Description = value.Description,
                Adress = value.Adress,
                PhoneNumber = value.PhoneNumber,
                Email = value.Email
            };
        }
    }
}
