using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetAuthorByBlogIdQueryResult
    {
        public int BlogId { get; set; }
        public string AuthorName{ get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorPicture { get; set; }

    }
}
