using CarBook.Application.Interfaces.TagCloudİnterFaces;
using CarBook.Domain.Entities;
using CarBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarBookContext _context;

        public TagCloudRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<TagCloud> GetTagCloudsWithBlog(int BlogId)
        {
            var values = _context.TagClouds.Include(x => x.Blog).Where(x => x.BlogId == BlogId).ToList();
            return values;
        }
    }
}
