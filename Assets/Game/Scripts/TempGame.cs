using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempGame : MonoBehaviour
{
    public ProjectTank.TankPrefabContainer prefabContainer;

    public void Awake()
    {
        ProjectTank.TankCreator tankCreator = new ProjectTank.TankCreator(prefabContainer);
        tankCreator.CreateNew("Tank", new ProjectTank.PlanedVector3().Set(0f, 0f));
        tankCreator.CreateNew("Tank", new ProjectTank.PlanedVector3().Set(0f, 3f));
    }
}
