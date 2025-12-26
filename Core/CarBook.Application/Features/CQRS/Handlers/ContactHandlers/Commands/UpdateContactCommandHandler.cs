using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Commands
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand request)
        {
            var value = await _repository.GetByIdAsync(request.ContactId);
            value.Name = request.Name;
            value.Email = request.Email;
            value.Subject = request.Subject;
            value.Message = request.Message;
            value.SendDate = request.SendDate;
            await _repository.UpdateAsync(value);
        }
    }
}
