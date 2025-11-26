using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.AuthorQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.AuthorResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler: IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return new GetAuthorByIdQueryResult
            {
                AuthorId = value.AuthorId,
                Name = value.Name,
                Description
            = value.Description,
                ImageUrl = value.ImageUrl
            };
        }
    }
}

