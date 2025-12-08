using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.BlogQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.BlogResults;
using BitirmeÖdevi_CarReservation.Application.Interface.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepositoy _blogRepository;
        public GetAllBlogsWithAuthorQueryHandler(IBlogRepositoy blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetAllBlogsWithAuthorsList();
            return values.Select(b => new GetAllBlogsWithAuthorQueryResult
            {
                AuthorId = b.AuthorId, 
                BlogId = b.BlogId,
                CategoryID = b.CategoryID,
                CreatedDate = b.CreatedDate,
                CoverImageUrl = b.CoverImageUrl,
                Title = b.Title,
                AuthorName = b.Author.Name,
                Description = b.Description,
                AuthorDescription = b.Author.Description,
                AuthorImageUrl = b.Author.ImageUrl,

            }).ToList();
        }
    }
}
