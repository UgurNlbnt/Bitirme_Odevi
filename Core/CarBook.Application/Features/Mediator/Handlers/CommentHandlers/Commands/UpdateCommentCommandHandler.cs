using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Commands
{
    //UpdateComment
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public UpdateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.CommentId);
            value.Description = request.Description;
            value.CreatedDate = request.CreatedDate;
            value.UserImageurl = request.UserImageurl;
            value.BlogId = request.BlogId;
            value.Name = request.Name;
            value.Email = request.Email;
            await _repository.UpdateAsync(value);
        }

    }
}
