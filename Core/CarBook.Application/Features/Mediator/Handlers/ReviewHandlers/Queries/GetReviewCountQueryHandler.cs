using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers.Queries
{
    public class GetReviewCountQueryHandler : IRequestHandler<GetReviewCountQuery, List<GetReviewCountQueryResult>>
    {
        private readonly IRepository<Review> _repository;

        public GetReviewCountQueryHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewCountQueryResult>> Handle(GetReviewCountQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetAllAsync();
            return reviews.Select(x => new GetReviewCountQueryResult
            {
                ReviewId = x.ReviewId,
                CarId = x.CarId,
                CustomerImage = x.CustomerImage,
                CustomerName = x.CustomerName,
                ReviewDate = x.ReviewDate,
                RaytingValue = x.RaytingValue,
                Comment = x.Comment
            }).ToList();
        }
    }
}
