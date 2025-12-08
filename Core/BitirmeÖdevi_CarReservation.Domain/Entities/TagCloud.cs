using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Domain.Entities
{
    public class TagCloud
    {
        public int TagCloudId { get; set; }
        public string Title { get; set; }
        public int BlodId { get; set; }
        public Blog Blog { get; set; }

    }
}
