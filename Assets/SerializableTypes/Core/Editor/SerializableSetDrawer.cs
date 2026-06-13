using UnityEditor;
using UnityEngine;


namespace SerializableTypes.Editor {

    /// <summary>
    /// Draw the wrapper class as a list. Getting rid of additional foldouts.
    /// Shows warning if there are duplicates.
    /// </summary>
    [CustomPropertyDrawer(typeof(SerializableSet<>))]
    public class SerializableSetDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            SerializedProperty list = property.FindPropertyRelative("_set");
            float listHeight = EditorGUI.GetPropertyHeight(list);
            EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, listHeight), list, label);

            if (property.FindPropertyRelative("_hasDuplicates").boolValue) {
                Rect messagePos = new(position.position.x, position.position.y + listHeight, position.width, EditorGUIUtility.singleLineHeight * 2);
                EditorGUI.HelpBox(messagePos, "This HashSet has duplicate values", MessageType.Warning);
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            float height = EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_set"));
            if (property.FindPropertyRelative("_hasDuplicates").boolValue) {
                height += EditorGUIUtility.singleLineHeight * 2;
            }
            return height;
        }
    }

}
