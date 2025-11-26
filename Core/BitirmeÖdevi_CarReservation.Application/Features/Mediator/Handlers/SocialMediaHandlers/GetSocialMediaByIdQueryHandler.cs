using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.SocialMediaQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.SocialMediaResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return new GetSocialMediaByIdQueryResult
            {
                SocialMediaId = value.SocialMediaId,
                Name = value.Name,
                Url = value.Url,
                IconUrl = value.IconUrl

            };
        }
    }
}
