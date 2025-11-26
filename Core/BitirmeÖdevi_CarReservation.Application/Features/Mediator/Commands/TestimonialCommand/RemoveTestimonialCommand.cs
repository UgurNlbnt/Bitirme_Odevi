using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.TestimonialCommand
{
    public class RemoveTestimonialCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveTestimonialCommand(int id)
        {
            Id = id;
        }
    }
}
