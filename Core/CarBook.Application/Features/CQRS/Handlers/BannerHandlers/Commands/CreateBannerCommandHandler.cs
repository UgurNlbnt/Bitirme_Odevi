using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Commands
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBannerCommand request)
        {
            var value = new Banner()
            {
                Title = request.Title,
                Description = request.Description,
                VideoDescription = request.VideoDescription,
                VideoUrl = request.VideoUrl
            };
            await _repository.CreateAsync(value);
        }
    }
}
