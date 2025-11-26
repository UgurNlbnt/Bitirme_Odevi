using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.LocationQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Queries.TestimonialQueries;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.LocationResults;
using BitirmeÖdevi_CarReservation.Application.Features.Mediator.Results.TestimonialResults;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeÖdevi_CarReservation.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult
            {
                Name = x.Name,
                TestimonialId = x.TestimonialId,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Tİtle = x.Tİtle
            }).ToList();
        }
    }
}
