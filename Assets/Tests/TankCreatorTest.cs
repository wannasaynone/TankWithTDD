using NUnit.Framework;
using NSubstitute;

namespace ProjectTank.Test
{
    public class TankCreatorTest  
    {
        [Test]
        public void Create_new_tank()
        {
            string dummyTankPrefabName = "TankPrefab";
            UnityEngine.GameObject dummyTank = new UnityEngine.GameObject();

            IPrefabContainer tankPrefabContainer = Substitute.For<IPrefabContainer>();
            tankPrefabContainer.GetClone(dummyTankPrefabName).Returns(dummyTank);

            TankCreator tankCreator = new TankCreator(tankPrefabContainer);

            PlanedVector3 startPosition = new PlanedVector3().Set(5f, 6f);
            Tank eventReceivedTank = null;
            UnityEngine.GameObject eventReceivedTankGameObject = null;

            System.Action<Tank, UnityEngine.GameObject> testAction = delegate (Tank tank, UnityEngine.GameObject cloneGameObject)
            {
                eventReceivedTank = tank;
                eventReceivedTankGameObject = cloneGameObject;
            };
            TankCreator.OnNewTankCreated += testAction;

            Tank createdTank = tankCreator.CreateNew(dummyTankPrefabName, startPosition);

            Assert.IsNotNull(eventReceivedTank);
            Assert.AreEqual(eventReceivedTank, createdTank);

            Assert.IsNotNull(eventReceivedTankGameObject);
            Assert.AreEqual(dummyTank, eventReceivedTankGameObject);

            PlanedVector3 createdPosition = createdTank.CurrentStats.GetPosition();
            Assert.IsTrue(UnityEngine.Mathf.Approximately(createdPosition.X, startPosition.X));
            Assert.IsTrue(UnityEngine.Mathf.Approximately(createdPosition.Z, startPosition.Z));
        }
    }
}
