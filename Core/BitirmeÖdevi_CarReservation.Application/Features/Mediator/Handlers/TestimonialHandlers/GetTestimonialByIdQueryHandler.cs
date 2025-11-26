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
        public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
        {
            private readonly IRepository<Testimonial> _repository;

            public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
            {
                _repository = repository;
            }

            public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);

                return new GetTestimonialByIdQueryResult
                {
                    TestimonialId = value.TestimonialId,
                    Name = value.Name,
                    Comment = value.Comment,
                    ImageUrl = value.ImageUrl,
                    Tİtle = value.Tİtle
                };
            }
        }
 }

