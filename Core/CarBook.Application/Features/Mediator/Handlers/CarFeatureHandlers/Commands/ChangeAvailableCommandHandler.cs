using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers.Commands
{
    public class ChangeAvailableCommandHandler : IRequestHandler<ChangeAvailableCommand>
    {
        private readonly IRepository<CarFeature> _repository;

        public ChangeAvailableCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ChangeAvailableCommand request, CancellationToken cancellationToken)
        {
            var carFeature = await _repository.GetByIdAsync(request.CarFeatureId);
            if (carFeature.Avaiable == request.Avaiable)
            {
                carFeature.Avaiable = carFeature.Avaiable;
            }
            else
            {
                carFeature.Avaiable = request.Avaiable;
            }
            await _repository.UpdateAsync(carFeature);
        }
    }
}
