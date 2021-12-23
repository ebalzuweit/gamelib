using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.ebalzuweit.gamelib
{
    public class SampleScript : MonoBehaviour
    {
        [SerializeField]
        private IntReference sampleInt;

        public void Increment()
        {
            sampleInt.Value++;
        }

        public void Decrement()
        {
            sampleInt.Value--;
        }
    }
}
