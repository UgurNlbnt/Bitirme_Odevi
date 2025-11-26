using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.FooterAdressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.FooterAdressQueries
{
    public class GetFooterAdressByIdQuery : IRequest<GetFooterAdressByIdQueryResult>
    {
        public int Id { get; set; }
        public GetFooterAdressByIdQuery(int id) 
        {
            Id = id;
        }
    }
}
