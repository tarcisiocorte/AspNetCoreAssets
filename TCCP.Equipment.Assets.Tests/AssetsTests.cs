using NUnit.Framework;
using NUnit.Framework.Internal;
using TCCP.Equipment.Assets.Business.Impl.Services;

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
            Assert.Equals(result.Count, 1);
        }
    }
}