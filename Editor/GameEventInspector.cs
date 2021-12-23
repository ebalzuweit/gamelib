using UnityEditor;
using UnityEngine;

namespace com.ebalzuweit.gamelib
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var raiseEvent = GUILayout.Button(new GUIContent("Raise"));
            if (raiseEvent)
            {
                (target as GameEvent).Raise();
            }
        }
    }
}
