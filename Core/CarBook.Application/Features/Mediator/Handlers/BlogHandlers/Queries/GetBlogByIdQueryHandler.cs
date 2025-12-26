using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Queries
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _blogRepository;

        public GetBlogByIdQueryHandler(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _blogRepository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult()
            {
                AuthorId = value.AuthorId,
                BlogId = value.BlogId,
                CategoryId = value.CategoryId,
                Title = value.Title,
                CoverImageUrl = value.CoverImageUrl,
                CreatedDate = value.CreatedDate,
                Description = value.Description
            };
        }
    }
}
