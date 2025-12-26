using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);

    }
}
//Task işlemin sürecini taşır, işlem bittiğinde de sana “tamamlandı” mesajı ve varsa sonucu getirir.
//Task = işlem nesnesi(durumunu tutar).
//await = o işlem bitene kadar bekle ama thread’i bloklama.