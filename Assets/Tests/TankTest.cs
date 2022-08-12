using NUnit.Framework;

namespace ProjectTank.Test
{
    public class TankTest
    {
        [Test]
        public void create()
        {
            UnityEngine.Vector3 startPosition = UnityEngine.Vector3.zero;
            int startHP = 100;
            int startAttack = 10;

            Tank tankInstance = new Tank(startPosition, startHP, startAttack);

            Assert.AreEqual(startPosition, tankInstance.CurrentStats.Position);
            Assert.AreEqual(startHP, tankInstance.CurrentStats.HP);
            Assert.AreEqual(startAttack, tankInstance.CurrentStats.Attack);
        }


    }
}