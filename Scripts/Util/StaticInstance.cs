using UnityEngine;

namespace com.ebalzuweit.gamelib
{
    /// <summary>
    /// An abstract base class for <see cref="MonoBehaviour"/>s to hold an instance reference.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }
        protected virtual void Awake() => Instance = this as T;

        protected virtual void OnApplicationQuit()
        {
            Instance = null;
            Destroy(gameObject);
        }
    }
}
