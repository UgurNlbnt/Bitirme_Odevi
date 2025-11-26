using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Results.AboutResults;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.AuthorQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.AuthorResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAuthorQueryResult
            {
                Name = x.Name,
                AuthorId = x.AuthorId,
                Description = x.Description,
                ImageUrl = x.ImageUrl


            }).ToList();
        }
    }
}
