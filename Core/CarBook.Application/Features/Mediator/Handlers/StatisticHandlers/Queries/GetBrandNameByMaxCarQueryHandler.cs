using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers.Queries
{
    public class GetBrandNameByMaxCarQueryHandler : IRequestHandler<GetBrandNameByMaxCarQuery, GetBrandNameByMaxCarQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetBrandNameByMaxCarQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        public async  Task<GetBrandNameByMaxCarQueryResult> Handle(GetBrandNameByMaxCarQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetBrandNameByMaxCar();
            return new GetBrandNameByMaxCarQueryResult()
            {
                BrandNameByMaxCar = value,
            };
        }
    }
}
//👉 MediatR diyor ki:

//“Ben tüm Handle metotlarını Task tabanlı (asenkron) çalıştırırım.”
//Bu yüzden senin metodun da Task döndürmek zorunda.
//Task döndürmek için de iki yol var:
//async yazarsın(içinde await varsa).
//Task.FromResult(...) kullanırsın(içinde await yoksa).
//Yani kısaca:
//async yazmamızın sebebi = MediatR’nin Task tabanlı çalışması zorunluluğu.
//🔹 Task ile ilişkisi:

//async metotların dönüş tipi her zaman Task veya Task<T> olur.
//Çünkü Task, “gelecekte dönecek sonucu” temsil eder.