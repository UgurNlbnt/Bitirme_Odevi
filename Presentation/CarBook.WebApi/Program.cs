using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Commands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Commands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Queries;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Commands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Queries;
using CarBook.Application.Interfaces;
using CarBook.Application.Services;
using CarBook.Application.Validators.ReviewValidators;
using CarBook.Infrastructure.Context;
using CarBook.Persistence.Repositories;
using CarBook.WebApi.Extensions;
using CarBook.WebApi.Hubs;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient(); /*✔ HttpClient servisini ekler.*/
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
// “IRepository<T> hangi T ile çağrılırsa, aynı T ile Repository<T> oluştur ve onu ver.”

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddProjectDependencies();

builder.Services
    .AddFluentValidationAutoValidation();       // “Eğer bir controller action’ına gelen modelin (command, dto vs.) bir Validator sınıfı varsa, o validator’ı otomatik olarak çalıştır.”“Validator’ı otomatik devreye sokan satır.”
builder.Services.AddValidatorsFromAssembly(typeof(CreateReviewValidator).Assembly);
//“CreateReviewValidator ve UpdateReviewValidator hangi assembly’delerse, o assembly’lerdeki tüm validator’ları bul, kaydet.”
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

app.UseCors("SignalRPolicy"); /*"SignalRPolicy adlı CORS kurallarını şimdi aktif et, kullan"*/
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.MapHub<CarHub>("/carHub");/*✔ SignalR hub’ın adresini belirler.*//*👉 “CarHub sınıfı artık bu adresten çalışacak: / carHub”*/

app.Run();
