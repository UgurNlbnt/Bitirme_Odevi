using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.SocialMediaCommands;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
  
        public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
        {
            private readonly IRepository<SocialMedia> _repository;

            public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
            {
                _repository = repository;
            }

            public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                await _repository.CreateAsync(new SocialMedia
                {
                    Name = request.Name,
                    Url = request.Url,
                    IconUrl = request.Icon
                });
            }
        }
}
