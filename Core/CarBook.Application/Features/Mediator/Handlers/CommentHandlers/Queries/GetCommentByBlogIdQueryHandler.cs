using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarRepositories;
using CarBook.Application.Interfaces.CommentInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Queries
{
    public class GetCommentByBlogIdQueryHandler : IRequestHandler<GetCommentByBlogIdQuery, List<GetCommentByBlogIdQueryResult>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentByBlogIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentByBlogIdQueryResult>> Handle(GetCommentByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _commentRepository.GetCommentsWithBlog(request.Id);
            return values.Select(x => new GetCommentByBlogIdQueryResult()
            {
                CommentId = x.CommentId,
                BlogName = x.Blog.Title,
                UserImageurl = x.UserImageurl,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Email = x.Email,
                Name = x.Name,
            }).ToList();
        }
    }
}
