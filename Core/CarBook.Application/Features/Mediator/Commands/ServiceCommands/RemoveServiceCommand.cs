using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.ServiceCommands
{
    public class RemoveServiceCommand:IRequest
    {
        public int ServicesId { get; set; }

        public RemoveServiceCommand(int servicesId)
        {
            ServicesId = servicesId;
        }
    }
}
