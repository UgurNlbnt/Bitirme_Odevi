using CarBook.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly CarBookContext _context;

        public DashboardController(CarBookContext context)
        {
            _context = context;
        }

        [HttpGet("GetFuelCategoryState")]
        public async Task<IActionResult> GetFuelCategoryState()
        {
            var value = await _context.Cars.GroupBy(x => x.Fuel).Select(x => new
            {
                fueltype = x.Key,
                count = x.Count()
            })
            .ToListAsync();
            return Ok(value);

        }
        [HttpGet("GetCarByCarBrand")]
        public async Task<IActionResult> GetCarByCarBrand()
        {
              var value = await _context.Brands.GroupBy(x =>x.Name).Select(x => new
              {
                  Name = x.Key,
                  Count = x.Count()
              }).ToListAsync();
              return Ok(value);

        }
        [HttpGet("GetRentACarStateByLocation")]
        public async Task<IActionResult> GetRentACarStateByLocation()
        {
            var value = _context.RentACars.Include(y => y.Car).Include(b => b.Location).Where(m => m.Available == true).GroupBy(d => d.Location.Name).Select(k => new
            {
                LocationName = k.Key,
                AvailableCarCount = k.Count()
            });
            return Ok(value);
        }
    }
}
