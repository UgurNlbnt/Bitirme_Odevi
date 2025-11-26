using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.PricingQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.PricingResults;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.ServiceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceQuery: IRequest<List<GetServiceQueryResult>>
    {

    }
}
