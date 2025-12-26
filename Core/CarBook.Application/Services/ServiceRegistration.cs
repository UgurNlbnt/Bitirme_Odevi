using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Services
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly);
            });


            //Bu metot sayesinde MediatR, ServiceRegistration katmanındaki Request ve Handler sınıflarını otomatik bulur ve kaydeder.
            //Hangi Request hangi Handler’a gidecekse, bunu da kendi içinde eşleştirir.
        }
    }
}
//diyor ki:

//“Git, ServiceRegistration’ın bulunduğu assembly’i tara ve içindeki IRequestHandler sınıflarını MediatR’a kaydet.”

//Yani bu durumda Application katmanının assembly’si taranıyor — ki handler’ların (GetFeatureQueryHandler, CreateFeatureCommandHandler vb.) zaten orada olduğu için bulunuyor ✅