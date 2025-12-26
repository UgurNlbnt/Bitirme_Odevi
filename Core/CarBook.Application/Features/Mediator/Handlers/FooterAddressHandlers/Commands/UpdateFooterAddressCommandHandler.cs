using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers.Commands
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddresCommand>
    {
        private readonly IRepository<FooterAdress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddresCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FooterAdressId);
            value.Address = request.Address;
            value.Phone= request.Phone;
            value.Email = request.Email;
            value.Description = request.Description;
            await _repository.UpdateAsync(value);
        }
    }
}
