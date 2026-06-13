using UnityEditor;
using UnityEngine;

namespace SerializableTypes.Editor {

    /// <summary>
    /// Draw the wrapper without foldouts.
    /// </summary>
    [CustomPropertyDrawer(typeof(SerializableStack<>))]
    public class SerializableStackDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.PropertyField(position, property.FindPropertyRelative("_stack"), label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_stack"));
        }
    }

}
