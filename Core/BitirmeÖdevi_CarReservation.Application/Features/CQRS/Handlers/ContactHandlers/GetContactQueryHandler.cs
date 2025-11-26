
using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Results.ContactResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(b => new GetContactQueryResult
            {
                ContactId = b.ContactId,
                Name = b.Name,
                Email = b.Email,
                Message = b.Message,
                SendDate = b.SendDate,
                Subject = b.Subject
            }).ToList();
        }
    }
}
