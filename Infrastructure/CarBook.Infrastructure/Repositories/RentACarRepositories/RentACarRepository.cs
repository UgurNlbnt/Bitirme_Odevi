using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarBookContext _context;

        public RentACarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values =await _context.RentACars.Where(filter).Include(y =>y.Car).ThenInclude(b=> b.CarPricings).ThenInclude(b => b.Pricing).Include(x =>x.Car).ThenInclude(b=>b.Brand).ToListAsync();
            //Hayır, ThenInclude kullanabilmen için öncesinde Include kullanman gerekir.
            //Çünkü ThenInclude, sadece Include ile başlayan bir ilişki zincirinin devamını temsil eder.
            return values;
        }
    }
}
//Expression<Func<RentACar, bool>> filter
//Dışarıdan bir filtreleme koşulu alıyor
//Örnek: car => car.Price > 1000 veya car => car.Brand == "BMW"
//Yani aslında expression diyerek o şartı dışarıdan alıyoruz ve bu şartı Where metodunda kullanılabilir bir hale getiriyoruz.normal function methodu sadece execute edilir ama expression yaparak farklı yerlerde kullanılabilir hale getiriyoruz dimi kısaca