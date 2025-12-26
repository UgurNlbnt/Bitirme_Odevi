using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand:IRequest
    {
        public int TestimonialId { get; set; }

        public RemoveTestimonialCommand(int testimonialId)
        {
            TestimonialId = testimonialId;
        }
    }
}
