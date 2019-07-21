using System.Collections.Generic;
using System.Linq;
using TCCP.Equipment.Assets.Business.Models;
using TCCP.Equipment.Assets.Business.Services;

namespace TCCP.Equipment.Assets.Business.Impl.Services
{
    public class DataInMemoryAssetsService : IAssetsService
    {
        private readonly List<Asset> _assets = new List<Asset>();
        private long _currentId = 0;
        
        public IReadOnlyCollection<Asset> GetAll()
        {
            return _assets.AsReadOnly();
        }

        public Asset GetById(long id)
        {
            return _assets.SingleOrDefault(g => g.Id == id);
        }

        public Asset Update(Asset asset)
        {
            var toUpdate = _assets.SingleOrDefault(g => g.Id == asset.Id);

            if (toUpdate == null)
            {
                return null;
            }

            toUpdate.Name = asset.Name;
            return toUpdate;
        }

        public Asset Add(Asset asset)
        {
            asset.Id = ++_currentId;
            _assets.Add(asset);
            return asset;
        }
    }
}