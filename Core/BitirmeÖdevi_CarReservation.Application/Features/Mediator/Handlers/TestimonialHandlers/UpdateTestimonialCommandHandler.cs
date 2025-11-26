using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.LocationCommands;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.TestimonialCommand;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;
        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.TestimonialId);
            values.Name = request.Name;
            values.Comment = request.Comment;
            values.ImageUrl = request.ImageUrl;
            values.Tİtle = request.Tİtle;
            await _repository.UpdateAsync(values);
        }
    }
}
