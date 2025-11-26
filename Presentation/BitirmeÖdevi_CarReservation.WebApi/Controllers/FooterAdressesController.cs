using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.FeatureCommands;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Commands.FooterAdressCommand;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.FooterAdressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeÖdevi_CarReservation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAdressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FooterAdressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAdressList()
        {
            var result = await _mediator.Send(new GetFooterAdressQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FooterAdressByIdList(int id)
        {
            var values = await _mediator.Send(new GetFooterAdressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAdress(CreateFooterAdressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Bilgisi Başarılı bir şekilde eklendi.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateFooterAdress(UpdateFooterAdressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Bilgisi Başarılı bir şekilde güncellendi.");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAdress(int id)
        {
            await _mediator.Send(new RemoveFooterAdressCommand(id));
            return Ok("Footer Bilgisi Başarılı bir şekilde silindi.");
        }
    }
}
