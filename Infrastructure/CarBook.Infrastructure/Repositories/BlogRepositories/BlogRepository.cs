using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogWithAuthorAndCategory()
        {
             return _context.Blogs.Include(x => x.Author).Include(y => y.Category).ToList();
        }

        public Blog GetAuthorByBlogId(int blogId)
        {
            return _context.Blogs.Include(x => x.Author).Where(z => z.BlogId == blogId).FirstOrDefault()!;
        }

        public List<Blog> GetLast3BlogWithAuthorAndCategory()
        {
            return _context.Blogs.Include(y => y.Author).Include(z => z.Category).OrderByDescending(x => x.BlogId).Take(3).ToList();
        }
    }
}
