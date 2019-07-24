using NUnit.Framework;
using NUnit.Framework.Internal;
using TCCP.Equipment.Assets.Business.Impl.Services;
using TCCP.Equipment.Assets.Business.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Get_All_Records_When_is_Loaded()
        {
            DataInMemoryAssetsService dataMemory = new DataInMemoryAssetsService();
            var result = dataMemory.GetAll();
            Assert.AreEqual(result.Count, 0);
        }

        [Test]
        public void Get_Asset_Record_By_Id()
        {
            DataInMemoryAssetsService dataMemory = new DataInMemoryAssetsService();
            dataMemory.Add(new Asset() {Id = 1, Name = "Base Unit"});
            var result = dataMemory.GetById(1);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Name, "Base Unit");
        }

        [Test]
        public void Asset_Record_Id_DoesNot_Exists()
        {
            DataInMemoryAssetsService dataMemory = new DataInMemoryAssetsService();
            dataMemory.Add(new Asset() { Id = 1, Name = "Base Unit" });
            var result = dataMemory.GetById(50);
            Assert.IsNull(result);
        }
    }
}