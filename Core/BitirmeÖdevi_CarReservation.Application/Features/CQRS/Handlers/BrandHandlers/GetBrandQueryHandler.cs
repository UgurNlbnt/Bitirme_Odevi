using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Results.BrandResult;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _brandRepository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values = await _brandRepository.GetAllAsync();
            return values.Select(b => new GetBrandQueryResult
            {
                BrandId = b.BrandId,
                Name = b.Name
            }).ToList();
        }
    }
}
