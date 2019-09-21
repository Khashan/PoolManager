using UnityEngine;

namespace Anderson.PoolManager.Test
{
    public class TestPoolManagerCalls : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] m_Prefabs;

        public void UsePoolObject(int id)
        {
            PoolManager.Instance.UseObjectFromPool(m_Prefabs[id], Random.insideUnitCircle * 5, Quaternion.identity);
        }
    }
}