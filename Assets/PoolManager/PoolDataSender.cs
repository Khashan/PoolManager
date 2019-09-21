using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anderson.PoolManager
{
    public class PoolDataSender : MonoBehaviour
    {
        [SerializeField]
        private List<PoolManager.PoolStruct> m_PoolData = new List<PoolManager.PoolStruct>();

        private void Start()
        {
            PoolManager.Instance.InitalizePools(m_PoolData);
        }
    }
}