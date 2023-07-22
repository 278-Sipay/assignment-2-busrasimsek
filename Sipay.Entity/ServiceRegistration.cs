using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sipay.Entity.Context;
using Sipay.Entity.Repository.TransactionRepository;
using System.Diagnostics;

namespace Sipay.Entity
{
    public static class ServiceRegistration
    {
        public static void DataAccessRegister(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("DbContext");
            services.AddDbContext<SipayDbContext>(x =>
            {
                x.UseNpgsql(connString)
                    .LogTo(x => Debug.WriteLine(x));
                x.UseLazyLoadingProxies(false);
                x.EnableSensitiveDataLogging();
            });
            

            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
