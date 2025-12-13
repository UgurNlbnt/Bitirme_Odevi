using BitirmeÖdevi_CarReservation.Application.Features.Repository_Pattern.CommentRepositories;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using BitirmeÖdevi_CarReservation.Persistence.Context;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.Select(x=> new Comment
            {
                CommentId = x.CommentId,
                BlogId = x.BlogId,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Name = x.Name
            }).ToList();
        }

        public void Creat(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(Comment entity)
        {
            var values = _context.Comments.Find(entity.CommentId);
            _context.Comments.Remove(values);
            _context.SaveChanges();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

    }
}
