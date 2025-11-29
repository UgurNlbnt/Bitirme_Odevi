using BitirmeÖdevi_CarReservation.Application.Interface.BlogInterfaces;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using BitirmeÖdevi_CarReservation.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepositoy
    {
        private readonly CarBookContext _context;
        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }
        public List<Blog> GetLast3BlogsWithAuthorsList()
        {
            var valurs = _context.Blogs.Include(b => b.Author).OrderByDescending(b => b.BlogId).Take(3).ToList();
            return valurs;
        }
    }
}
