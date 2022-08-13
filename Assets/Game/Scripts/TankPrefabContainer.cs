using UnityEngine;

namespace ProjectTank
{
    [CreateAssetMenu(menuName = "Tank Prefab Container")]
    public class TankPrefabContainer : ScriptableObject, IPrefabContainer
    {
        [SerializeField] private GameObject[] m_prefabs;

        public GameObject GetClone(string name)
        {
            for (int i = 0; i < m_prefabs.Length; i++)
            {
                if (m_prefabs[i].name.ToLower().Trim() == name.ToLower().Trim())
                {
                    return Instantiate(m_prefabs[i]);
                }
            }

            return null;
        }
    }
}