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
    public class GetAuthorByBlogIdQueryHandler : IRequestHandler<GetAuthorByBlogIdQuery, GetAuthorByBlogIdQueryResult>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAuthorByBlogIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetAuthorByBlogIdQueryResult> Handle(GetAuthorByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var value = _blogRepository.GetAuthorByBlogId(request.BlogId); ;
            return new GetAuthorByBlogIdQueryResult()
            {
                BlogId = value.BlogId,
                AuthorName = value.Author.Name,
                AuthorDescription = value.Author.Description,
                AuthorPicture = value.Author.ImageUrl
            };
        }
    }
}
