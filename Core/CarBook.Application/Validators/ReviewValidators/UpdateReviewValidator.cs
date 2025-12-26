using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator:AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Müşteri Ad-Soyad Boş Geçilemez")
                .MinimumLength(5).WithMessage("Müşteri Ad-Soyad En Az 5 Karakter Olmalıdır")
                .MaximumLength(50).WithMessage("Müşteri Ad-Soyad En Fazla 50 Karakter Olmalıdır");

            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Puanlama Boş Geçilemez")
                .InclusiveBetween(1, 5).WithMessage("Puanlama 1 ile 5 arasında olmalıdır");

            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum Boş Geçilemez")
                .MinimumLength(10).WithMessage("Yorum En Az 10 Karakter Olmalıdır")
                .MaximumLength(500).WithMessage("Yorum En Fazla 500 Karakter Olmalıdır");

            RuleFor(y => y.CustomerImage).NotEmpty().WithMessage("Müşteri Resmi Boş Geçilemez")
                .MinimumLength(5).WithMessage("Müşteri Resmi En Az 10 Karakter Olmalıdır")
            .MaximumLength(200).WithMessage("Müşteri Resmi En Fazla 200 Karakter Olmalıdır");
        }
    }
}
