using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.PricingResults;
using MediatR;
using System.Collections.Generic;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
    {
    }
}
