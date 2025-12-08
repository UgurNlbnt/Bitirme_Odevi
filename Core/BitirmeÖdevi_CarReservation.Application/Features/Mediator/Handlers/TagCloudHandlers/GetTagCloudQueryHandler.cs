using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.TagCloudQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.TagCloudResult;
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
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTagCloudQueryResult()
            {
                TagCloudId = x.TagCloudId,
                Title = x.Title,
                BlodId = x.BlodId
            }).ToList();
        }
    }
}