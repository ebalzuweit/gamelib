using System;
using UnityEditor;

namespace gamelib
{
    [Serializable]
    public class FloatReference : VariableReference<float>
    {
#if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(FloatReference))]
        private class FloatReferenceDrawer : VariableReferenceDrawer { }
#endif
    }
}
