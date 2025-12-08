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
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        private readonly IBlogRepositoy _repositry;
        public GetBlogByAuthorIdQueryHandler(IBlogRepositoy repositry)
        {
            _repositry = repositry;
        }
        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var blogs = _repositry.GetBlogByAuthorId(request.Id);
            var result = blogs.Select(blog => new GetBlogByAuthorIdQueryResult
            {
                BlogId = blog.BlogId,
                AuthorName = blog.Author.Name,
                AuthorDescription = blog.Author.Description,
                AuthorImageUrl = blog.Author.ImageUrl,
                AuthorId = blog.AuthorId
            }).ToList();

            return result;
        }
    }
}
