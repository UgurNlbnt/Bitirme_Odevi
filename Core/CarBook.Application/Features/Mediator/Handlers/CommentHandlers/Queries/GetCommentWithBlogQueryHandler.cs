using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Queries
{
    public class GetCommentWithBlogQueryHandler : IRequestHandler<GetCommentWithBlogQuery, List<GetCommentWithBlogQueryResult>>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentWithBlogQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentWithBlogQueryResult>> Handle(GetCommentWithBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCommentWithBlogQueryResult()
            {
                CommentId = x.CommentId,
                Name = x.Name,
                UserImageurl = x.UserImageurl,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                BlogName = x.Blog.Title,
                Email = x.Email
            }).ToList();
        }
    }
}
