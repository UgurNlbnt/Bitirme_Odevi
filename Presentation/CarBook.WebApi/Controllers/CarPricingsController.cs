using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : Controller
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCarPricings()
        {
            var values = await _mediator.Send(new GetCarPricingQuery());
            return Ok(values);
        }
		[HttpGet("GetCarPricingWithTimePeriodQuery")]
		public async Task<IActionResult> GetCarPricingWithTimePeriod()
		{
			var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
			return Ok(values);
		}
		[HttpGet("GetCarPricingWithCarByPricingId")]
		public async Task<IActionResult> GetCarPricingWithCarByPricingId(int pricingıd)
		{
			var values = await _mediator.Send(new GetCarPricingWithBrandByPricingIdQuery(pricingıd));
			return Ok(values);
		}
	}
}
