using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarByIdQuery
    {
        public GetCarByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }

    }
}
