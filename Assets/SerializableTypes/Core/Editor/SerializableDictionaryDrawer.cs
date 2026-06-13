using UnityEditor;
using UnityEngine;

namespace SerializableTypes.Editor {

    /// <summary>
    /// Draw the wrapper class as a list. Getting rid of additional foldouts.
    /// Shows warning if there are duplicates.
    /// </summary>
    [CustomPropertyDrawer(typeof(SerializableDictionary<,>))]
    public class SerializableDictionaryDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            SerializedProperty list = property.FindPropertyRelative("_dictionary");
            EditorGUI.PropertyField(position, list, label);

            if (property.FindPropertyRelative("hasDuplicates").boolValue) {
                float listHeight = EditorGUI.GetPropertyHeight(list);
                Rect messagePos = new(position.position.x, position.position.y + listHeight, position.width, EditorGUIUtility.singleLineHeight * 2);
                EditorGUI.HelpBox(messagePos, "This dictionary has duplicate keys", MessageType.Warning);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            float height = EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_dictionary"));
            if (property.FindPropertyRelative("hasDuplicates").boolValue) {
                height += EditorGUIUtility.singleLineHeight * 2;
            }
            return height;
        }
    }

}
