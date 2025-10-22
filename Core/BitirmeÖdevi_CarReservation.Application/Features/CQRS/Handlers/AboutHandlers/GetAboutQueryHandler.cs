using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Results.AboutResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _reporsitory;

        public GetAboutQueryHandler(IRepository<About> reporsitory)
        {
            _reporsitory = reporsitory;
        }

        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values = await _reporsitory.GetAllAsync();
            return values.Select(x=> new GetAboutQueryResult
            {
                    AboutId = x.AboutId,
                    Title = x.Title,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl

            }).ToList();
        }
    }
}
