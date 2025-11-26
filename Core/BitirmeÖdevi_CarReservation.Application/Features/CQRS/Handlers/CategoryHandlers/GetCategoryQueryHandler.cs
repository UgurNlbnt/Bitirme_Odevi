using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Results.CategoryResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _CategoryRepository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _CategoryRepository = repository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _CategoryRepository.GetAllAsync();
            return values.Select(b => new GetCategoryQueryResult
            {
                CategoryId = b.CategoryId,
                Name = b.Name
            }).ToList();
        }
    }
}
