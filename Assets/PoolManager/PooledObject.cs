using UnityEngine;
using UnityEngine.SceneManagement;

namespace Anderson.PoolManager
{
    public abstract class PooledObject : MonoBehaviour
    {
        [Tooltip("Show the StackTrace to know the source of its destroy (Require DebugMode)")]
        [SerializeField]
        private bool m_DestroyErrorSourceOnly = false;

        [Tooltip("Show Error Log in the console")]
        [SerializeField]
        private bool m_ActiveDebugMode = false;

        private GameObject m_PoolOwner;
        public GameObject PoolOwner
        {
            get { return m_PoolOwner; }
        }

        private string m_StackTrace;
        private bool m_SceneHasBeenUnloaded = false;
        private void Awake()
        {
#if UNITY_EDITOR
            SceneManager.sceneUnloaded += OnSceneUnloaded;
#endif
        }

#if UNITY_EDITOR
        private void OnSceneUnloaded(Scene scene)
        {
            if (scene == gameObject.scene)
            {
                m_SceneHasBeenUnloaded = true;
            }
        }
#endif

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
            if (!m_SceneHasBeenUnloaded)
            {
                if (m_ActiveDebugMode)
                {
                    Debug.LogError(GetDestroyErrorMessage());
                }

                SceneManager.sceneUnloaded -= OnSceneUnloaded;
            }
#endif
        }

#if UNITY_EDITOR
        private string GetDestroyErrorMessage()
        {
            string errorMessage = "(Ignore it if you were stopping unity play or changing scene)\nPooledObject should've never been destroyed! \n{0}";

            if (!m_DestroyErrorSourceOnly)
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
}