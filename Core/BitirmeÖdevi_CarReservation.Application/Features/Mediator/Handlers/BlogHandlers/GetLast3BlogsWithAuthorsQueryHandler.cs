using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Results.CarResults;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.BlogQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.BlogResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Application.Interface.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepositoy _blogRepository; 
        public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepositoy blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetLast3BlogsWithAuthorsList();
            return values.Select(b => new GetLast3BlogsWithAuthorsQueryResult
            {
                AuthorId = b.AuthorId,
                BlogId = b.BlogId,
                CategoryID = b.CategoryID,
                CreatedDate = b.CreatedDate,
                CoverImageUrl = b.CoverImageUrl,
                Title = b.Title,
                AuthorName = b.Author.Name

            }).ToList();
        }
    }
}
