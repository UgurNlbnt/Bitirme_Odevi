using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.PricingResults;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.ServiceResults;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
    {

    }
}
