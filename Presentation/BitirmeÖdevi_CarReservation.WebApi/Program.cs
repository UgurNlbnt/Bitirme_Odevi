
using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.AboutHandlers;
using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.BannerHandlers;
using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.BrandHandlers;
using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.CarHandlers;
using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.CategoryHandlers;
using BitirmeÖdevi_CarReservation.Application.Features.CQRS.Handlers.ContactHandlers;
using BitirmeÖdevi_CarReservation.Application.Interface;
using BitirmeÖdevi_CarReservation.Application.Interface.CarInterfaces;
using BitirmeÖdevi_CarReservation.Persistence.Context;
using BitirmeÖdevi_CarReservation.Persistence.Repositories;
using BitirmeÖdevi_CarReservation.Persistence.Repositories.CarRepositories;
using BitirmeÖdevi_CarReservation.Application.Services;
using BitirmeÖdevi_CarReservation.Persistence.Repositories.BlogRepositories;
using BitirmeÖdevi_CarReservation.Application.Interface.BlogInterfaces;
using BitirmeÖdevi_CarReservation.Application.Interface.CarPricingInterfaces;
using BitirmeÖdevi_CarReservation.Persistence.Repositories.CarPricingRepositories;
using BitirmeÖdevi_CarReservation.Application.Interface.TagCloudInterfaces;
using BitirmeÖdevi_CarReservation.Persistence.Repositories.TagCloudRepositories;
using BitirmeÖdevi_CarReservation.Application.Features.Repository_Pattern.CommentRepositories;
using BitirmeÖdevi_CarReservation.Persistence.Repositories.CommentRepositories;


namespace BitirmeÖdevi_CarReservation.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<CarBookContext>();
            builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
            builder.Services.AddScoped(typeof(IBlogRepositoy), typeof(BlogRepository));
            builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
            builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));


            //AboutHandlerları ekledik.
            builder.Services.AddScoped<GetAboutByIdQueryHandler>();
            builder.Services.AddScoped<CreateAboutCommandHandler>();
            builder.Services.AddScoped<GetAboutQueryHandler>();
            builder.Services.AddScoped<UpdateAboutCommandHandler>();
            builder.Services.AddScoped<RemoveAboutCommandHandler>();

            builder.Services.AddScoped<GetBannerByIdQueryHandler>();
            builder.Services.AddScoped<CreateBannerCommandHandler>();
            builder.Services.AddScoped<GetBannerQueryHandler>();
            builder.Services.AddScoped<UpdateBannerCommandHandler>();
            builder.Services.AddScoped<RemoveBannerCommandHandler>();

            builder.Services.AddScoped<GetBrandByIdQueryHandler>();
            builder.Services.AddScoped<CreateBrandCommandHandler>();
            builder.Services.AddScoped<GetBrandQueryHandler>();
            builder.Services.AddScoped<UpdateBrandCommandHandler>();
            builder.Services.AddScoped<RemoveBrandCommandHandler>();

            builder.Services.AddScoped<GetCarByIdQueryHandler>();
            builder.Services.AddScoped<CreateCarCommandHandler>();
            builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
            builder.Services.AddScoped<GetCarQueryHandler>();
            builder.Services.AddScoped<UpdateCarCommandHandler>();
            builder.Services.AddScoped<RemoveCarCommandHandler>();
            builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();

            builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
            builder.Services.AddScoped<CreateCategoryCommandHandler>();
            builder.Services.AddScoped<GetCategoryQueryHandler>();
            builder.Services.AddScoped<UpdateCategoryCommandHandler>();
            builder.Services.AddScoped<RemoveCategoryCommandHandler>();

            builder.Services.AddScoped<GetContactByIdQueryHandler>();
            builder.Services.AddScoped<CreateContactCommandHandler>();
            builder.Services.AddScoped<GetContactQueryHandler>();
            builder.Services.AddScoped<UpdateContactCommandHandler>();
            builder.Services.AddScoped<RemoveContactCommandHandler>();


            builder.Services.AddApplicationService(builder.Configuration);



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
