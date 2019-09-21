using System.Linq;
using UnityEngine;

public abstract class PooledObject : MonoBehaviour
{
    [SerializeField]
    private bool m_DestroyErrorSourceOnly = false;

    private GameObject m_PoolOwner;
    public GameObject PoolOwner
    {
        get { return m_PoolOwner; }
    }

    private string m_StackTrace;

    public virtual void InitPooledObject(GameObject a_PoolOwner)
    {
        m_PoolOwner = a_PoolOwner;
        gameObject.SetActive(false);
    }

    protected virtual void OnDisable()
    {
        #if UNITY_EDITOR
        m_StackTrace = StackTraceUtility.ExtractStackTrace();
        #endif

        PoolManager.Instance.ReturnedPooledObject(this, PoolOwner);
    }

    protected virtual void OnDestroy()
    {
        #if UNITY_EDITOR
        Debug.LogError(GetDestroyErrorMessage());
        #endif
    }

    #if UNITY_EDITOR
    private string GetDestroyErrorMessage()
    {
        string errorMessage = "PooledObject should've never been destroyed! \n{0}";

        if(!m_DestroyErrorSourceOnly)
        {
            errorMessage = string.Format(errorMessage, m_StackTrace);
        }
        else
        {
            errorMessage = string.Format(errorMessage, GetDestroyerSource());
        }

        return errorMessage;
    }

    private string GetDestroyerSource()
    {
        string[] traces = m_StackTrace.Split('\n');
        return traces[traces.Length - 2] + "\n";
    }
    #endif
}
