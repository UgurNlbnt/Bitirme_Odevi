using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.TagCloudQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.TagCloudResult;
using BitirmeÖdevi_CarReservation.Application.Interface.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _tagCloudRepository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _tagCloudRepository.GetTagCloudsByBlogId(request.BlogId);
            return values.Select(x => new GetTagCloudByBlogIdQueryResult()
            {
                BlogId = x.BlodId,
                TagCloudId = x.TagCloudId,
                Title = x.Title
            }).ToList();
        }
    }
}
