using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAuthorByBlogIdQueryHandler")]
        public async Task<IActionResult> GetAuthorByBlogId(int id)
        {
            var values = await _mediator.Send(new GetAuthorByBlogIdQuery(id));
            return Ok(values);
        }
        [HttpGet("GetLast3BlogWithCategoryandAuthorList")]
        public async Task<IActionResult> GetLast3Blog()
        {
            var values = await _mediator.Send(new GetBlogWithAuthorandCategoryQuery());
            return Ok(values);
        }
        [HttpGet("GetAllBlogWithOthersList")]
        public async Task<IActionResult> GetAllBlogWithOthersList()
        {
            var values = await _mediator.Send(new GetAllBlogWithOthersQuery());
            return Ok(values);
        }
        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Silme İşlemi Başarılı Bir Şekilde Gerçekleşti");
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme İşlemi Başarılı Bir Şekilde Gerçekleşti");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme İşlemi Başarılı Bir Şekilde Gerçekleşti");
        }
    }
}
