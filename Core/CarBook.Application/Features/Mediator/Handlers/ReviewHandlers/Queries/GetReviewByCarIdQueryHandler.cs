using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers.Queries
{
	public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _reviewRepository;

		public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var reviews = _reviewRepository.GetAllReviewByCarId(request.CarId);
			return reviews.Select(y => new GetReviewByCarIdQueryResult()
			{
				CarId = y.CarId,
				ReviewId = y.ReviewId,
				ReviewDate = y.ReviewDate,
				CustomerImage = y.CustomerImage,
				CustomerName = y.CustomerName,
				Comment = y.Comment,
				RaytingValue = y.RaytingValue
			}).ToList();
		}
	}
}
