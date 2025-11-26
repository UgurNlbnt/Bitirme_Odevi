using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.ServiceCommand
{
    public class RemoveServiceCommand :IRequest
    {
        public RemoveServiceCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }


    }
}
