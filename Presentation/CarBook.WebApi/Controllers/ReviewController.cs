using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ReviewController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet("GetReviewsByCarId")]
		public async Task<IActionResult> GetReviewsByCarId(int id)
		{
			var values = await _mediator.Send(new GetReviewByCarIdQuery(id));
			return Ok(values);
		}
        [HttpGet("GetAllReviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            var values = await _mediator.Send(new GetReviewCountQuery());
            return Ok(values);
        }
		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommand command)
		{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(command);
            return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        }
		[HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
		{
            if (!ModelState.IsValid)
            {
				return BadRequest(ModelState);
            }
				await _mediator.Send(command);
				return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _mediator.Send(new RemoveReviewCommand(id));
            return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        }
    }
}

/*
 builder.Services.AddFluentValidationAutoValidation();
Bu middleware’i aktif eder.
Dolayısıyla model binding tamamlanır tamamlanmaz ASP.NET şunu yapar:

“Bu modele (CreateReviewCommand) ait bir FluentValidator var mı?”
“Varmış: CreateReviewValidator.”
“O zaman kurallarını çalıştırayım.”

✅ Yani FluentValidation, ModelState oluşturulmadan önce devreye girer
ve hatalı alanları ModelState içine otomatik olarak ekler.
 
 */
