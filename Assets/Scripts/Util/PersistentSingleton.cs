using UnityEngine;

namespace gamelib
{
    /// <summary>
    /// A <see cref="Singleton{T}"/> that persists between Scenes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}
