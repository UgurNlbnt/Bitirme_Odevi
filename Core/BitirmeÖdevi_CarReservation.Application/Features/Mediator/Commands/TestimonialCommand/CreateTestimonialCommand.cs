using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.TestimonialCommand
{
    public class CreateTestimonialCommand : IRequest
    {
        public string Name { get; set; }
        public string Tİtle { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }

    }
}
