using UnityEngine;

namespace Anderson.PoolManager.Test
{
    public class PooledPrefabObjectTest : PooledObject
    {
        [SerializeField]
        private bool m_AutoDisable = false;
        [SerializeField]
        private float m_LifeTime = -1f;

        private float m_CurrentLifeTime = 0f;

        private void OnEnable()
        {
            m_CurrentLifeTime = m_LifeTime;
        }

        private void Update()
        {
            if (m_AutoDisable)
            {
                m_CurrentLifeTime -= Time.deltaTime;
                if (m_CurrentLifeTime <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
