using System;
using UnityEditor;
using UnityEngine;

namespace com.ebalzuweit.gamelib
{
    [Serializable]
    public class VariableReference<T>
    {
        public bool UseConstant = true;
        public T ConstantValue;
        public Variable<T> Variable;

        public T Value
        {
            get
            {
                return UseConstant ? ConstantValue : Variable.Value;
            }
            set
            {
                if (UseConstant)
                    ConstantValue = value;
                else
                    Variable.Value = value;
            }
        }

#if UNITY_EDITOR
        public class VariableReferenceDrawer : PropertyDrawer
        {
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                EditorGUI.BeginProperty(position, label, property);
                {
                    position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
                    var buttonRect = new Rect(position.x, position.y, 20f, position.height);
                    var valueRect = new Rect(position.x + 20f, position.y, position.width - 20, position.height);

                    var useConstant = property.FindPropertyRelative(nameof(UseConstant)).boolValue;

                    // display dropdown menu for constant / variable
                    var icon = EditorGUIUtility.Load("icons/d_UnityEditor.SceneHierarchyWindow.png") as Texture2D;
                    var menuOpen = EditorGUI.DropdownButton(buttonRect, new GUIContent(icon), FocusType.Keyboard, new GUIStyle());
                    if (menuOpen)
                    {
                        var menu = new GenericMenu();
                        menu.AddItem(new GUIContent("Use Constant"),
                            useConstant,
                            () => SetUseConstant(property, true));
                        menu.AddItem(new GUIContent("Use Variable"),
                            !useConstant,
                            () => SetUseConstant(property, false));

                        menu.ShowAsContext();
                    }

                    // display active value
                    if (useConstant == true)
                    {
                        EditorGUI.PropertyField(valueRect, property.FindPropertyRelative(nameof(ConstantValue)), GUIContent.none);
                    }
                    else
                    {
                        EditorGUI.ObjectField(valueRect, property.FindPropertyRelative(nameof(Variable)), GUIContent.none);
                    }
                }
                EditorGUI.EndProperty();
            }

            private void SetUseConstant(SerializedProperty property, bool value)
            {
                var prop = property.FindPropertyRelative(nameof(UseConstant));
                prop.boolValue = value;
                property.serializedObject.ApplyModifiedProperties();
            }
        }
#endif
    }
}
