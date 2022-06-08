using System;
using UnityEditor;

namespace gamelib
{
    [Serializable]
    public class BoolReference : VariableReference<bool>
    {
#if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(BoolReference))]
        private class BoolReferenceDrawer : VariableReferenceDrawer { }
#endif
    }
}
