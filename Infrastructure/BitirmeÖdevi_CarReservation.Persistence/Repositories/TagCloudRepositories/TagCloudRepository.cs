using BitirmeÖdevi_CarReservation.Application.Interface.TagCloudInterfaces;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using BitirmeÖdevi_CarReservation.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarBookContext _context;
        public TagCloudRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<TagCloud> GetTagCloudsByBlogId(int id)
        {
           var value = _context.TagClouds.Where(x => x.BlodId == id).ToList();
            return value;
        }
    }
}
