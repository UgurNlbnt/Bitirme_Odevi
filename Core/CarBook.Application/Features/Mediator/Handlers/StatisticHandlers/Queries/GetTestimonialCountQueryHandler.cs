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
    public class GetTestimonialCountQueryHandler : IRequestHandler<GetTestimonialCountQuery, GetTestimonialCountQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetTestimonialCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetTestimonialCountQueryResult> Handle(GetTestimonialCountQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetTestimonialCount();
            return new GetTestimonialCountQueryResult()
            {
                TestimonialCount = value
            };
        }
    }
}
