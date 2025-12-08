using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.TagCloudResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByIdQuery : IRequest<GetTagCloudByIdQueryResult>
    {
        public int Id { get; set; }

        public GetTagCloudByIdQuery(int id)
        {
            Id = id;
        }
    }
}
