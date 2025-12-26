using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers.Commands
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand request)
        {
            var value = await _repository.GetByIdAsync(request.CarId);
            value.BrandId = request.BrandId;
            value.CoverImageUrl = request.CoverImageUrl;
            value.Km = request.Km;
            value.Transmission = request.Transmission;
            value.Seat = request.Seat;
            value.Luggage = request.Luggage;
            value.Fuel = request.Fuel;
            value.BigImageUrl = request.BigImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
