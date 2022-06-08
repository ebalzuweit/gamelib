using UnityEngine;
using UnityEngine.Events;

namespace gamelib
{
    public class Timer : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float _duration = 1f;
        [SerializeField] private bool _looping = false;
        [SerializeField] private UnityEvent _onElapsed;

        private float _lastElapsedTime;

        /// <summary>
        /// Destroy the <see cref="GameObject"/> this <see cref="MonoBehaviour"/> is attached to.
        /// (Utility function to allow for <see cref="Timer"/> to destroy its GameObject after firing.)
        /// </summary>
        public void DestroyGameObject()
        {
            Destroy(gameObject);
        }

        private void OnElapsed()
        {
            _lastElapsedTime = Time.time;
            _onElapsed.Invoke();

            if (!_looping)
                Destroy(this);
        }

        private void Start()
        {
            _lastElapsedTime = Time.time;
        }

        private void Update()
        {
            if (Time.time >= _lastElapsedTime + _duration)
            {
                OnElapsed();
            }
        }
    }
}
