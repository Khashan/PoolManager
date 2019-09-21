using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPoolManagerCalls : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_Prefabs;

    public void UsePoolObject(int id)
    {
        PoolManager.Instance.UseObjectFromPool(m_Prefabs[id], Random.insideUnitCircle * 5, Quaternion.identity);
    }
}
