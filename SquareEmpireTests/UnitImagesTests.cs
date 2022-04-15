using NUnit.Framework;
using SquareEmpire.models.map.image;

namespace SquareEmpireTests
{
    public class UnitImagesTests
    {
        // [SetUp]
        // public void Setup()
        // {
        // }

        [Test]
        public void ImagesContainsTest()
        {
            var defaultWarrior = UnitImages.Get("DefaultWarrior");
            Assert.NotNull(defaultWarrior);
        }
    }
}