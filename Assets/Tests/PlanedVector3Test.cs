using NUnit.Framework;
using ProjectTank;

namespace ProjectTank.Test
{
    public class PlanedVector3Test
    {
        [Test]
        public void Create()
        {
            PlanedVector3 planedVector3 = new PlanedVector3().Set(1f, 2f);

            Assert.IsTrue(UnityEngine.Mathf.Approximately(planedVector3.X, 1f));
            Assert.IsTrue(UnityEngine.Mathf.Approximately(planedVector3.Z, 2f));
        }

        [Test]
        public void Add()
        {
            PlanedVector3 planedVector3 = new PlanedVector3().Add(2f, 3f);
            
            Assert.IsTrue(UnityEngine.Mathf.Approximately(planedVector3.X, 2f));
            Assert.IsTrue(UnityEngine.Mathf.Approximately(planedVector3.Z, 3f));
        }

        [Test]
        public void Set()
        {
            PlanedVector3 planedVector3 = new PlanedVector3().Set(5f, 6f);

            Assert.IsTrue(UnityEngine.Mathf.Approximately(planedVector3.X, 5f));
            Assert.IsTrue(UnityEngine.Mathf.Approximately(planedVector3.Z, 6f));
        }

        [Test]
        public void Chain_set_then_add()
        {
            PlanedVector3 planedVector3 = new PlanedVector3().Set(5f, 6f).Add(-5f, -6f);

            Assert.IsTrue(UnityEngine.Mathf.Approximately(planedVector3.X, 0f));
            Assert.IsTrue(UnityEngine.Mathf.Approximately(planedVector3.Z, 0f));
        }

        [Test]
        public void Chain_add_then_set()
        {
            PlanedVector3 planedVector3 = new PlanedVector3().Add(5f, 6f).Set(-5f, -6f);

            Assert.IsTrue(UnityEngine.Mathf.Approximately(planedVector3.X, -5f));
            Assert.IsTrue(UnityEngine.Mathf.Approximately(planedVector3.Z, -6f));
        }
    }
}
