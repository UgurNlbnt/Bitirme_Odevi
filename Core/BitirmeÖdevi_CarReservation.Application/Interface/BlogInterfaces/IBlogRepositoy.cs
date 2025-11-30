using BitirmeÖdevi_CarReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Interface.BlogInterfaces
{
    public interface IBlogRepositoy
    {
        public List<Blog> GetLast3BlogsWithAuthorsList();
        public List<Blog> GetAllBlogsWithAuthorsList();
    }
}
