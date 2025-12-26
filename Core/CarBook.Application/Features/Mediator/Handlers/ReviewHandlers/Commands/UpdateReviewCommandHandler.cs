using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers.Commands
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public UpdateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ReviewID);
            value.CustomerName = request.CustomerName;
            value.CustomerImage = request.CustomerImage;
            value.Comment = request.Comment;
            value.RaytingValue = request.RaytingValue;
            value.CarId = request.CarId;
            value.ReviewDate = request.ReviewDate;
            await _repository.UpdateAsync(value);
        }
    }
}
