using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.PricingCommands
{
    public class UpdatePricingCommand : IRequest 
    {
        public int PricingId { get; set; }
        public string Name { get; set; }
    }
}
