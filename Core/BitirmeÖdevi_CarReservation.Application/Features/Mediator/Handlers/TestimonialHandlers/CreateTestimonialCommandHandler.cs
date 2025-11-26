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
    
        public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
        {
            private readonly IRepository<Testimonial> _repository;
            public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
            {
                _repository = repository;
            }

            public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
            {
                await _repository.CreateAsync(new Testimonial
                {
                    Name = request.Name,
                    Comment = request.Comment,
                    ImageUrl = request.ImageUrl,
                    Tİtle = request.Tİtle
                });
            }
        }
 }

