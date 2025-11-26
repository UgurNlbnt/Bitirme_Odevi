using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.LocationCommands;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.TestimonialCommand;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.LocationQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeÖdevi_CarReservation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LocationsList()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var values = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans bilgisi başarılı bir şekilde eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return Ok("Referans bilgisi başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans bilgisi bir şekilde güncellendi.");
        }
    }
}
