using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers.Queries
{
    public class GetCarCountByKmBiggerThen30000QueryHandler : IRequestHandler<GetCarCountByKmBiggerThen30000Query, GetCarCountByKmBiggerThen30000QueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountByKmBiggerThen30000QueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByKmBiggerThen30000QueryResult> Handle(GetCarCountByKmBiggerThen30000Query request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarCountByKmBiggerThen30000();
            return new GetCarCountByKmBiggerThen30000QueryResult()
            {
                CarCountByKmBiggerThen30000 = value
            };
        }
    }
}
