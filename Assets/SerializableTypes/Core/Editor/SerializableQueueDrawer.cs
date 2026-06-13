using UnityEditor;
using UnityEngine;

namespace SerializableTypes {

    /// <summary>
    /// Draw the wrapper without foldouts.
    /// </summary>
    [CustomPropertyDrawer(typeof(SerializableQueue<>))]
    public class SerializableQueueDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.PropertyField(position, property.FindPropertyRelative("_queue"), label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_queue"));
        }
    }

}
