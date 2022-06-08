using System;
using UnityEditor;

namespace gamelib
{
    [Serializable]
    public class IntReference : VariableReference<int>
    {
#if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(IntReference))]
        private class IntReferenceDrawer : VariableReferenceDrawer { }
#endif
    }
}
