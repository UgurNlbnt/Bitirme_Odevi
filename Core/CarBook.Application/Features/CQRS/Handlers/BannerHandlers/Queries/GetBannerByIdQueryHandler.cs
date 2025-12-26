using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Queries
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery request)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetBannerByIdQueryResult()
            {
                BannerId = value.BannerId,
                VideoDescription = value.VideoDescription,
                VideoUrl = value.VideoUrl,
                Title = value.Title,
                Description = value.Description
            };
        }
    }
}
