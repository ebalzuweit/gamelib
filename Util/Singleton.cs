using UnityEngine;

namespace com.ebalzuweit.gamelib
{
    /// <summary>
    /// A <see cref="StaticInstance{T}"/> that will destroy itself if another already exists.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            if (Instance != null) Destroy(gameObject);
            base.Awake();
        }
    }
}
