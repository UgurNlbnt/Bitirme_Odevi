using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Repository_Pattern.CommentRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        void Creat(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetById(int id);
    }
}
