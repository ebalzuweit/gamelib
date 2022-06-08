using System;
using UnityEditor;

namespace gamelib
{
    [Serializable]
    public class StringReference : VariableReference<string>
    {
#if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(StringReference))]
        private class StringReferenceDrawer : VariableReferenceDrawer { }
#endif
    }
}
