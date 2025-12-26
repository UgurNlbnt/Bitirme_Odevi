using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers.Commands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarFeaturByCarId(int id)
        {
            var value = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> ChangeCarFeatureAvaliableState(ChangeAvailableCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme İşlemi Başarılı");
        }
        [HttpPost]
        public async Task<IActionResult> AddCarFeature(CreateCarFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme İşlemi Başarılı");
        }
    }
}
