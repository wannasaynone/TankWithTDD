using NUnit.Framework;
using NSubstitute;

namespace ProjectTank.Test
{
    public class PrefabContainerTest 
    {
        [Test]
        public void Get()
        {
            UnityEngine.GameObject prefabDummy = new UnityEngine.GameObject();

            IPrefabContainer prefabContainer = Substitute.For<IPrefabContainer>();
            prefabContainer.GetClone("someName").Returns(prefabDummy);

            Assert.AreEqual(prefabDummy, prefabContainer.GetClone("someName"));
        }
    }
}