using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Commands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Commands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Queries;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Commands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Queries;
using CarBook.Infrastructure.Context;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers.Commands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers.Queries;
using CarBook.Application.Interfaces.CarRepositories;
using CarBook.Persistence.Repositories.CarRepositories;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Queries;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Commands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Queries;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Commands;
using MediatR;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Application.Interfaces.CarPricingİnterfaces;
using CarBook.Persistence.Repositories.CarPricingRepositorites;
using CarBook.Application.Interfaces.TagCloudİnterFaces;
using CarBook.Persistence.Repositories.TagCloudRepositories;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Persistence.Repositories.CommentRepositories;
using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Persistence.Repositories.StatiscticRepositories;
using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Persistence.Repositories.RentACarRepositories;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Persistence.Repositories.CarFeatureRepositories;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Persistence.Repositories.CarDescriptionRepositories;
using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Persistence.Repositories.ReviewRepositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using System.Reflection.PortableExecutable;


namespace CarBook.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection Services)
        {
            //Context
            Services.AddScoped<CarBookContext>();

            Services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<CarBookContext>()
            .AddDefaultTokenProviders();

            //SignalR

            Services.AddCors(opt =>
            {
                opt.AddPolicy("SignalRPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed((host) => true);
                });
            });
            Services.AddSignalR();


            //About
            Services.AddScoped<GetAboutByIdQueryHandler>();
            Services.AddScoped<GetAboutQueryHandler>();
            Services.AddScoped<UpdateAboutCommandHandler>();
            Services.AddScoped<RemoveAboutCommandHandler>();
            Services.AddScoped<CreateAboutCommandHandler>();
            //Banner
            Services.AddScoped<GetBannerByIdQueryHandler>();
            Services.AddScoped<GetBannerQueryHandler>();
            Services.AddScoped<CreateBannerCommandHandler>();
            Services.AddScoped<UpdateBannerCommandHandler>();
            Services.AddScoped<RemoveBannerCommandHandler>();
            //Brand
            Services.AddScoped<GetBrandByIdQueryHandler>();
            Services.AddScoped<GetBrandQueryHandler>();
            Services.AddScoped<CreateBrandCommandHandler>();
            Services.AddScoped<UpdateBrandCommandHandler>();
            Services.AddScoped<RemoveBrandCommandHandler>();
            //Car
            Services.AddScoped<GetCarByIdQueryHandler>();
            Services.AddScoped<GetCarQueryHandler>();
            Services.AddScoped<CreateCarCommandHandler>();
            Services.AddScoped<UpdateCarCommandHandler>();
            Services.AddScoped<RemoveCarCommandHandler>();
            Services.AddScoped<GetCarWithBrandQueryHandler>();
            Services.AddScoped<GetLast5CarsWithBrandsQueryHandler>();
            //Category
            Services.AddScoped<GetCategoryByIdQueryHandler>();
            Services.AddScoped<GetCategoryQueryHandler>();
            Services.AddScoped<CreateCategoryCommandHandler>();
            Services.AddScoped<UpdateCategoryCommandHandler>();
            Services.AddScoped<RemoveCategoryCommandHandler>();
            //Contact
            Services.AddScoped<GetContactByIdQueryHandler>();
            Services.AddScoped<GetContactQueryHandler>();
            Services.AddScoped<CreateContactCommandHandler>();
            Services.AddScoped<UpdateContactCommandHandler>();
            Services.AddScoped<RemoveContactCommandHandler>();
            //İnterfaces
            Services.AddScoped<ICarRepository, CarRepository>();
            Services.AddScoped<IBlogRepository, BlogRepository>();
            Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
            Services.AddScoped<ITagCloudRepository, TagCloudRepository>();
            Services.AddScoped<ICommentRepository, CommentRepository>();
            Services.AddScoped<IStatisticRepository, StatisticRepository>();
            Services.AddScoped<IRentACarRepository, RentACarRepository>();
            Services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
            Services.AddScoped<ICarDescriptionRepository, CarDescriptionRepository>();
            Services.AddScoped<IReviewRepository, ReviewRepository>();


            return Services;
        }
    }
}
//Services.AddAuthentication()
//sisteme sadece şunu söylüyor:
//“Ben bir kimlik doğrulama sistemi kullanacağım.”
//Ama hangi sistemle yapılacağını söylemiyorsun.
//ASP.NET Core burada şunu der:
//“Tamam authentication kullanacaksın da, JWT mi? Cookie mi? API key mi? Bilmiyorum.”
//Yani altyapıyı açıyor ama bir varsayılan yöntem atanmıyor.



//AddAuthentication() Kimlik doğrulama altyapısını başlatır.
//(JwtBearerDefaults.AuthenticationScheme)	Varsayılan sistemin JWT olacağını belirtir.
//AddJwtBearer(...)	JWT doğrulama özelliğini ekler.
//(opt => { ... })	Token’ın nasıl doğrulanacağını (kurallarını) tanımlar.



//## 2️⃣ Kod Parça Parça Açıklama

//### A) `Services.AddCors(opt => { ... })`

//**Anlamı:**"Uygulamama CORS (çapraz kaynak paylaşımı) özelliğini ekle"

//Yani: "Backend'ime, farklı adreslerden gelen istekleri kabul etme yeteneği ver"

//-- -

//### B) `opt.AddPolicy("SignalRPolicy", builder => { ... })`

//**Anlamı:**"SignalRPolicy" adında bir **politika (kural seti)** oluştur.

//Düşün ki bu bir **güvenlik kuralı kitabı**. Bu kitaba "SignalRPolicy" adını veriyorsun.

//---

//### C) `builder.AllowAnyHeader()`

//**Anlamı:**"Gelen isteklerde **herhangi bir başlık (header)** olabilir, hepsine izin ver"

//* *Header nedir?** İstekle birlikte gönderilen ek bilgiler:
//```
//Authorization: Bearer token123
//Content - Type: application / json
//Custom - Header: some - value
//```

//`.AllowAnyHeader()` → "Hangi header gelirse gelsin, sorun yok"

//-- -

//### D) `builder.AllowAnyMethod()`

//**Anlamı:**"Herhangi bir **HTTP metoduna** izin ver"

//* *HTTP Metodları: **
//- `GET` → Veri al
//- `POST` → Veri gönder
//- `PUT` → Veri güncelle
//- `DELETE` → Veri sil
//- `OPTIONS`, `PATCH` vb.

//`.AllowAnyMethod()` → "GET de olabilir, POST da olabilir, DELETE de olabilir, hepsine izin ver"

//---

//### E) `builder.AllowCredentials()`

//**Anlamı:**"**Kimlik bilgileriyle** (credentials) gelen isteklere izin ver"

//* *Credentials nedir ? **
//-Cookies(çerezler)
//- Authentication headers(JWT token gibi)
//- HTTP authentication

//** Neden önemli?** SignalR bağlantıları genelde **uzun süreli ve kimlik doğrulamalı** olur. Kullanıcı bilgilerini taşımak gerekir.

//`.AllowCredentials()` → "Cookie veya token gönderebilirsin, kabul ederim"

//---

//### F) `builder.SetIsOriginAllowed((host) => true)`

//**Anlamı:**"**Her kaynağa (origin)** izin ver"

//* *Origin nedir?** İsteğin geldiği adres:
//```
//http://localhost:3000
//https://mywebsite.com
//https://example.com