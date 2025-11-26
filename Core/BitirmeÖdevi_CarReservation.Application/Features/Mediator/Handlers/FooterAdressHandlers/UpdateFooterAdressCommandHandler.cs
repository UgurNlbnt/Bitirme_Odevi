using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.FooterAdressCommand;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class UpdateFooterAdressCommandHandler : IRequestHandler<UpdateFooterAdressCommand>
    {
        private readonly IRepository<FooterAdress> _repository; 
        public UpdateFooterAdressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAdressCommand request, CancellationToken cancellationToken)
        {
           var value = await _repository.GetByIdAsync(request.FooterAdressId);
           value.PhoneNumber = request.PhoneNumber;
           value.Adress = request.Adress;
           value.Description = request.Description; 
           value.Email = request.Email; 
           await _repository.UpdateAsync(value);

        }
    }
}
