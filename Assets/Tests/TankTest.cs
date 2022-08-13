using NUnit.Framework;
using NSubstitute;

namespace ProjectTank.Test
{
    public class TankTest
    {
        [Test]
        public void Create()
        {
            PlanedVector3 startPosition = new PlanedVector3();
            int startHP = 100;
            int startAttack = 10;

            Tank tankInstance = new Tank(startPosition, startHP, startAttack);
            PlanedVector3 currentPos = tankInstance.CurrentStats.GetPosition();

            Assert.AreNotEqual(startPosition, currentPos);
            Assert.AreEqual(startHP, tankInstance.CurrentStats.HP);
            Assert.AreEqual(startAttack, tankInstance.CurrentStats.Attack);
        }

        [Test]
        public void Move()
        {
            Tank tankInstance = new Tank(new PlanedVector3(), 0, 0);

            tankInstance.Move(new PlanedVector3().Set(0f, 1f));
            PlanedVector3 currentPos = tankInstance.CurrentStats.GetPosition();

            Assert.IsTrue(UnityEngine.Mathf.Approximately(currentPos.X, 0f));
            Assert.IsTrue(UnityEngine.Mathf.Approximately(currentPos.Z, 1f));
        }

        [Test]
        public void Get_position()
        {
            Tank tankInstance = new Tank(new PlanedVector3().Set(5f, 6f), 0, 0);

            PlanedVector3 tankPosition = tankInstance.CurrentStats.GetPosition();

            Assert.IsTrue(UnityEngine.Mathf.Approximately(tankPosition.X, 5f));
            Assert.IsTrue(UnityEngine.Mathf.Approximately(tankPosition.Z, 6f));
        }

        [Test]
        public void Get_position_encapsulation()
        {
            Tank tankInstance = new Tank(new PlanedVector3().Set(5f, 6f), 0, 0);

            PlanedVector3 tankPosition_get1 = tankInstance.CurrentStats.GetPosition();
            PlanedVector3 tankPosition_get2 = tankInstance.CurrentStats.GetPosition();

            Assert.AreNotEqual(tankPosition_get1, tankPosition_get2);
        }

        [Test]
        public void Start_charging_cannon()
        {
            Tank tankInstance = new Tank(new PlanedVector3(), 0, 0);

            Tank receivedTank = null;

            System.Action<Tank> testAction = delegate(Tank attacker)
            {
                receivedTank = attacker;
            };

            Tank.OnStartToChargeCannon += testAction;
            tankInstance.StartCharge();

            Assert.AreEqual(tankInstance, receivedTank);
        }

        [Test]
        public void Cant_move_when_charging()
        {
            Tank tankInstance = new Tank(new PlanedVector3(), 0, 0);


            tankInstance.StartCharge();
            tankInstance.Move(new PlanedVector3().Set(0f, 1f));
            PlanedVector3 currentPos = tankInstance.CurrentStats.GetPosition();

            Assert.IsTrue(UnityEngine.Mathf.Approximately(currentPos.X, 0f));
            Assert.IsTrue(UnityEngine.Mathf.Approximately(currentPos.Z, 0f));
        }

        [Test]
        public void Fire_cannon()
        {
            Tank tankInstance = new Tank(new PlanedVector3(), 0, 0);

            Tank receivedAttacker = null;
            PlanedVector3 receivedEndPosition = null;

            System.Action<Tank, PlanedVector3> testAction = delegate(Tank attacker, PlanedVector3 endPostion)
            {
                receivedAttacker = attacker;
                receivedEndPosition = endPostion;
            };

            Tank.OnCannonFired += testAction;

            PlanedVector3 force = new PlanedVector3().Set(0f, 1f);

            tankInstance.FireCannon(force);

            Assert.AreEqual(tankInstance, receivedAttacker);
            Assert.IsTrue(UnityEngine.Mathf.Approximately(receivedEndPosition.X, 0f));
            Assert.IsTrue(UnityEngine.Mathf.Approximately(receivedEndPosition.Z, 1f));
        }
    }
}