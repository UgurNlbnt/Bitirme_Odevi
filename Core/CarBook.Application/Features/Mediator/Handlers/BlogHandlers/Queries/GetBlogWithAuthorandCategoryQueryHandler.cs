using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Queries
{
    public class GetBlogWithAuthorandCategoryQueryHandler : IRequestHandler<GetBlogWithAuthorandCategoryQuery, List<GetBlogWithAuthorandCategoryQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogWithAuthorandCategoryQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogWithAuthorandCategoryQueryResult>> Handle(GetBlogWithAuthorandCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetLast3BlogWithAuthorAndCategory();
            return values.Select(x => new GetBlogWithAuthorandCategoryQueryResult()
            {
                AuthorId = x.AuthorId,
                CategoryId = x.CategoryId,
                BlogId = x.BlogId,
                CategoryName = x.Category.Name,
                AuthorName = x.Author.Name,
                CoverImageUrl = x.CoverImageUrl,
                Title = x.Title,
                CreatedDate = x.CreatedDate
            }).ToList();
        }
    }
}
