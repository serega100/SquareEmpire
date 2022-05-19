using NUnit.Framework;
using SquareEmpire.view;

namespace SquareEmpireTests
{
    public class AssetsHolderTests
    {
        private AssetsHolder _assetsHolder;
        
        [SetUp]
        public void SetUp()
        {
            _assetsHolder = new AssetsHolder();
        }

        [Test]
        public void ShouldGetDefaultWarrior()
        {
            var defaultWarrior = _assetsHolder.GetImage("DefaultWarrior");
            Assert.NotNull(defaultWarrior);
        }
    }
}