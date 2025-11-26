using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Commands.CarCommand;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
                BigImageUrl= command.BigImageUrl,
                Luggage= command.Luggage,
                Km= command.Km,
                Model= command.Model,   
                Seat= command.Seat,
                Transmission= command.Transmission, 
                CoverImageUrl = command.CoverImageUrl,
                BrandId= command.BrandId,
                Fuel= command.Fuel
            });
        }
    }
}
