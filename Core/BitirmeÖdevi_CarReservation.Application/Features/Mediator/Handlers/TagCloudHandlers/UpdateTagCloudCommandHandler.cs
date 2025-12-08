using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.TagCloudCommands;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TagCloudId);
            value.Title = request.Title;
            value.TagCloudId = request.TagCloudId;
            await _repository.UpdateAsync(value);
        }
    }
}
