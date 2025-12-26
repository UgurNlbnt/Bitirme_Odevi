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
    public class GetAvgRentPriceForHourlyQueryHandler : IRequestHandler<GetAvgRentPriceForHourlyQuery, GetAvgRentPriceForHourlyQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetAvgRentPriceForHourlyQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAvgRentPriceForHourlyQueryResult> Handle(GetAvgRentPriceForHourlyQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetAvgRentPriceForHourly();
            return new GetAvgRentPriceForHourlyQueryResult()
            {
                AvgRentPriceForHourly = value
            };
        }
    }
}
