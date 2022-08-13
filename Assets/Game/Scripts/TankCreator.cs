using System;
using UnityEngine;

namespace ProjectTank
{
    public class TankCreator
    {
        private readonly IPrefabContainer tankPrefabContainer;

        public TankCreator(IPrefabContainer tankPrefabContainer)
        {
            this.tankPrefabContainer = tankPrefabContainer;
        }

        public static event Action<Tank, GameObject> OnNewTankCreated;

        public Tank CreateNew(string name, PlanedVector3 startPosition)
        {
            GameObject cloned = tankPrefabContainer.GetClone(name);
            cloned.transform.position = new Vector3(startPosition.X, 0f, startPosition.Z);

            Tank newTank = new Tank(startPosition, 100, 100);

            OnNewTankCreated?.Invoke(newTank, cloned);

            return newTank;
        }
    }
}