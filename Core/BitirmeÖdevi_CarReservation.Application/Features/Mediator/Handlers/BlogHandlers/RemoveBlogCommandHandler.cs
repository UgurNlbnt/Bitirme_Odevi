using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.BlogCommands;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.BlogHandlers
{
        public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
        {
            private readonly IRepository<Blog> _repository;
            public RemoveBlogCommandHandler(IRepository<Blog> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                await _repository.RemoveAsync(value);
            }
        }
}
