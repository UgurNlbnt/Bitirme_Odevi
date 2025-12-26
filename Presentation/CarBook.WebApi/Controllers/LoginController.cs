
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
    }
}
//Query: "Ben GetCheckAppUserQueryResult döndüreceğim" diyor(sadece söz)
//Handler: Gerçekten GetCheckAppUserQueryResult oluşturup döndürüyor(gerçek iş)
//IsExist görünüyor → Çünkü Query'de GetCheckAppUserQueryResult tipi belirtilmiş
//IsExist'e değer ulaşıyor → Çünkü Handler o property'ye değer atayıp döndürüyor