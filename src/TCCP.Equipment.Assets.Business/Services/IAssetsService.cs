using System.Collections.Generic;
using TCCP.Equipment.Assets.Business.Models;

namespace TCCP.Equipment.Assets.Business.Services
{
    public interface IAssetsService
    {
        IReadOnlyCollection<Asset> GetAll();

        Asset GetById(long id);

        Asset Update(Asset asset);

        Asset Add(Asset asset);
    }
}