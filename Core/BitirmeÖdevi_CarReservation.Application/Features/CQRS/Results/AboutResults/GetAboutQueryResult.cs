using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.CQRS.Results.AboutResults
{
    public class GetAboutQueryResult
    {
        //domaindeki abouttan gelen propertiyleri buraya ekledik. Bunlar about sınıfında gelmesini istediğim özellikler burada
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
