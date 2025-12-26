using CarBook.Application.Features.Mediator.Commands.CarDescriptionCommands;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers.Commands
{
    public class UpdateCarDescriptionCommandHandler : IRequestHandler<UpdateCarDescriptionCommand>
    {
        private readonly IRepository<CarDescription> _repository;
        private readonly ICarDescriptionRepository _carDescriptionRepository;

        public UpdateCarDescriptionCommandHandler(IRepository<CarDescription> repository, ICarDescriptionRepository carDescriptionRepository)
        {
            _repository = repository;
            _carDescriptionRepository = carDescriptionRepository;
        }

        public async Task Handle(UpdateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var existing = _carDescriptionRepository.GetCarDescriptionByCarId(request.CarId);
            if (existing == null)
            {
                var entity = new CarDescription
                {
                    CarId = request.CarId,
                    Details = request.Details
                };
                await _repository.CreateAsync(entity);
            }
            else
            {
                existing.Details = request.Details;
                await _repository.UpdateAsync(existing);
            }
        }
    }
}

