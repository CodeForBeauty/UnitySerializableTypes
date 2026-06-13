using UnityEditor;
using UnityEngine;

namespace SerializableTypes.Editor {

    [CustomPropertyDrawer(typeof(SerializableDictionary<,>.KeyValue))]
    public class DictionaryPairDrawer : PropertyDrawer {
        public override bool CanCacheInspectorGUI(SerializedProperty property) {
            return false;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (property.FindPropertyRelative("isDuplicate").boolValue) {
                GUI.backgroundColor = Color.red;
            }

            float lineHeight = EditorGUIUtility.singleLineHeight;
            Rect labelPos = new(position.position.x, position.position.y, position.width, lineHeight);
            EditorGUI.LabelField(labelPos, label);

            SerializedProperty keyProperty = property.FindPropertyRelative("Key");
            float keyHeight = EditorGUI.GetPropertyHeight(keyProperty);
            Rect keyPos = new(position.position.x, position.position.y + lineHeight + 2, position.width, keyHeight);

            EditorGUI.PropertyField(keyPos, keyProperty);

            GUI.backgroundColor = Color.white;

            SerializedProperty valProperty = property.FindPropertyRelative("Value");
            float valHeight = EditorGUI.GetPropertyHeight(valProperty);
            Rect valPos = new(keyPos.position.x, keyPos.position.y + keyHeight + 2, position.width, valHeight);

            EditorGUI.PropertyField(valPos, valProperty);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            float keyHeight = EditorGUI.GetPropertyHeight(property.FindPropertyRelative("Key")) + 2;
            float valHeight = EditorGUI.GetPropertyHeight(property.FindPropertyRelative("Value")) + 2;
            float labelHeight = EditorGUIUtility.singleLineHeight + 2;
            return keyHeight + valHeight + labelHeight;
        }
    }

}
