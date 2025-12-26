using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.TagCloudİnterFaces
{
    public interface ITagCloudRepository
    {
        List<TagCloud> GetTagCloudsWithBlog(int BlogId);
    }
}
