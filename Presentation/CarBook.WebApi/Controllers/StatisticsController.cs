using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("CarCount")]
        public async Task<IActionResult> CarCount()
        {
            var value = await _mediator.Send(new GetCarCountQuery());
            return Ok(value);
        }
        [HttpGet("LocationCount")]
        public async Task<IActionResult> LocationCount()
        {
            var value = await _mediator.Send(new GetLocationCountQuery());
            return Ok(value);
        }
        [HttpGet("BlogCount")]
        public async Task<IActionResult> BlogCount()
        {
            var value = await _mediator.Send(new GetBlogCountQuery());
            return Ok(value);
        }
        [HttpGet("AuthorCount")]
        public async Task<IActionResult> AuthorCount()
        {
            var value = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(value);
        }
        [HttpGet("BrandCount")]
        public async Task<IActionResult> BrandCount()
        {
            var value = await _mediator.Send(new GetBrandCountQuery());
            return Ok(value);
        }
        [HttpGet("AvgRentPriceForHourly")]
        public async Task<IActionResult> AvgRentPriceForHourly()
        {
            var value = await _mediator.Send(new GetAvgRentPriceForHourlyQuery());
            return Ok(value);
        }
        [HttpGet("AvgRentPriceForDaily")]
        public async Task<IActionResult> AvgRentPriceForDaily()
        {
            var value = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(value);
        }
        [HttpGet("AvgRentPriceForWeekly")]
        public async Task<IActionResult> AvgRentPriceForWeekly()
        {
            var value = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(value);
        }
        [HttpGet("AvgRentPriceForMonthly")]
        public async Task<IActionResult> AvgRentPriceForMonthly()
        {
            var value = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(value);
        }
        [HttpGet("CarCountByTranmissionIsAuto")]
        public async Task<IActionResult> CarCountByTranmissionIsAuto()
        {
            var value = await _mediator.Send(new GetCarCountByTranmissionIsAutoQuery());
            return Ok(value);
        }
        [HttpGet("BrandNameByMaxCar")]
        public async Task<IActionResult> BrandNameByMaxCar()
        {
            var value = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(value);
        }
        [HttpGet("BlogTitleByMaxBlogComment")]
        public async Task<IActionResult> BlogTitleByMaxBlogComment()
        {
            var value = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(value);
        }
        [HttpGet("CarCountByKmSmallerThen1000")]
        public async Task<IActionResult> CarCountByKmSmallerThen1000()
        {
            var value = await _mediator.Send(new GetCarCountByKmSmallerThen1000Query());
            return Ok(value);
        }
        [HttpGet("CarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> CarCountByFuelGasolineOrDiesel()
        {
            var value = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(value);
        }
        [HttpGet("CarCountByFuelElectric")]
        public async Task<IActionResult> CarCountByFuelElectric()
        {
            var value = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(value);
        }
        [HttpGet("CarBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> CarBrandAndModelByRentPriceDailyMax()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(value);
        }
        [HttpGet("CarBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> CarBrandAndModelByRentPriceDailyMin()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(value);
        }   
        [HttpGet("CarCountByKmBiggerThen30000")]
        public async Task<IActionResult> CarCountByKmBiggerThen30000Query()
        {
            var value = await _mediator.Send(new GetCarCountByKmBiggerThen30000Query());
            return Ok(value);
        }
        [HttpGet("FiveSeatCarCount")]
        public async Task<IActionResult> FiveSeatCarCountQuery()
        {
            var value = await _mediator.Send(new GetFiveSeatCarCountQuery());
            return Ok(value);
        }
        [HttpGet("LargeLuggageCarCount")]
        public async Task<IActionResult> LargeLuggageCarCountQuery()
        {
            var value = await _mediator.Send(new GetLargeLuggageCarCountQuery());
            return Ok(value);
        }

    }
}
