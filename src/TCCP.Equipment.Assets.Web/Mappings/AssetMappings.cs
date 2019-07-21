using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TCCP.Equipment.Assets.Business.Models;
using TCCP.Equipment.Assets.Web.Models;

namespace TCCP.Equipment.Assets.Web.Mappings
{
    public static class AssetMappings
    {
        public static AssetViewModel ToViewModel(this Asset model)
        {
            return model != null ? new AssetViewModel { Id = model.Id, Name = model.Name } : null;
        }
        
        public static Asset ToServiceModel(this AssetViewModel model)
        {
            return model != null ? new Asset { Id = model.Id, Name = model.Name } : null;
        }

        public static IReadOnlyCollection<AssetViewModel> ToViewModel(this IReadOnlyCollection<Asset> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<AssetViewModel>();
            }
            
            var assets = new AssetViewModel[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                assets[i] = model.ToViewModel();
                ++i;
            }

            return new ReadOnlyCollection<AssetViewModel>(assets);
        }
    }
}