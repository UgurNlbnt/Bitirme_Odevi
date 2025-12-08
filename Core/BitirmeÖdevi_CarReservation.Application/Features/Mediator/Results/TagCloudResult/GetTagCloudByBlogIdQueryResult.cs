using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.TagCloudResult
{
    public class GetTagCloudByBlogIdQueryResult
    {
        public int TagCloudId { get; set; }
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
}
