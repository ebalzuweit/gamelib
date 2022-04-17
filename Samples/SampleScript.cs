using UnityEngine;

namespace com.ebalzuweit.gamelib
{
    public class SampleScript : MonoBehaviour
    {
        [SerializeField]
        private IntReference sampleInt;
        [SerializeField]
        private Transform _sampleGoal;

        public void Increment()
        {
            sampleInt.Value++;
        }

        public void Decrement()
        {
            sampleInt.Value--;
        }

        private void Update()
        {
            var localPosition = _sampleGoal.localPosition;
            localPosition.y = Mathf.Sin(Time.time) * 2f;
            _sampleGoal.localPosition = localPosition;
        }
    }
}
