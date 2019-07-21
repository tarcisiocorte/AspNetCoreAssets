using System;
using System.Collections.Generic;
using Autofac;
using TCCP.Equipment.Assets.Business.Impl.Services;
using TCCP.Equipment.Assets.Business.Models;
using TCCP.Equipment.Assets.Business.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataInMemoryAssetsService>().Named<IAssetsService>("assetsService").SingleInstance();
            builder.RegisterDecorator<IAssetsService>((context, service) => new AssetsServiceDecorator(service), "assetsService");
        }

        private class AssetsServiceDecorator : IAssetsService
        {
            private readonly IAssetsService _inner;

            public AssetsServiceDecorator(IAssetsService inner)
            {
                _inner = inner;
            }
            
            public IReadOnlyCollection<Asset> GetAll()
            {
                Console.WriteLine($"######### Performing: {nameof(GetAll)} #########");
                return _inner.GetAll();
            }

            public Asset GetById(long id)
            {
                Console.WriteLine($"######### Performing: {nameof(GetById)} #########");
                return _inner.GetById(id);
            }

            public Asset Update(Asset asset)
            {
                Console.WriteLine($"######### Performing: {nameof(Update)} #########");
                return _inner.Update(asset);
            }

            public Asset Add(Asset asset)
            {
                Console.WriteLine($"######### Performing {nameof(Add)} #########");
                return _inner.Add(asset);
            }
        }
    }
}