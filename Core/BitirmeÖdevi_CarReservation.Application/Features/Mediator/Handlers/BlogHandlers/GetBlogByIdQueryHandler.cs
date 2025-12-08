using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.BlogQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.BlogResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return new GetBlogByIdQueryResult
            {
                BlogId = value.BlogId,
                AuthorId = value.AuthorId,
                Title = value.Title,
                CreatedDate = value.CreatedDate,
                CoverImageUrl = value.CoverImageUrl,
                CategoryID = value.CategoryID,
                Description = value.Description
            };
        }
    }
}
