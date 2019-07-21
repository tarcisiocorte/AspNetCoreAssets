using TCCP.Equipment.Assets.Business.Impl.Services;
using TCCP.Equipment.Assets.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddSingleton<IAssetsService, DataInMemoryAssetsService>();
            
            //more business services...

            return services;
        }
    }
}