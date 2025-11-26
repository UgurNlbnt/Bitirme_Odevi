using BitirmeÖdevi_CarReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.PricingResults
{
    public class GetPricingQueryResult
    {
        public int PricingId { get; set; }
        public string Name { get; set; }
    }
}
