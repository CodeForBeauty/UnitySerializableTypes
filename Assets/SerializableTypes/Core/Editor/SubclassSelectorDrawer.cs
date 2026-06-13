using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace SerializableTypes.Editor {

    [CustomPropertyDrawer(typeof(SubclassSelectorAttribute))]
    public class SubclassSelectorDrawer : PropertyDrawer {
        static private readonly Dictionary<Type, List<Type>> _cache = new();


        public override VisualElement CreatePropertyGUI(SerializedProperty property) {
            VisualElement container = new();

            if (property.propertyType != SerializedPropertyType.ManagedReference) {
                container.Add(new Label("[SerializeReference] required"));
                return container;
            }

            string typeName = property.managedReferenceValue == null
                ? "Null"
                : property.managedReferenceValue.GetType().Name;

            List<Type> types = GetTypes(GetPropertyType());
            List<string> options = types.ConvertAll(t => t != null ? t.Name : "Null");

            DropdownField dropdown = new(property.displayName, options, -1);

            dropdown.value = typeName;

            dropdown.RegisterValueChangedCallback(evt => {
                property.serializedObject.Update();
                Type t = types[dropdown.index];
                if (t != null) {
                    property.managedReferenceValue = Activator.CreateInstance(t);
                }
                else {
                    property.managedReferenceValue = null;
                }
                property.serializedObject.ApplyModifiedProperties();
            });

            container.Add(dropdown);

            if (property.managedReferenceValue != null) {
                Foldout refFoldout = new();

                var iterator = property.Copy();
                var end = iterator.GetEndProperty();

                bool enterChildren = true;

                while (iterator.NextVisible(enterChildren) &&
                       !SerializedProperty.EqualContents(iterator, end)) {
                    enterChildren = false;

                    refFoldout.Add(new PropertyField(iterator.Copy()));
                }
                /*PropertyField prop = new(property, typeName);
                container.Add(prop);*/
                container.Add(refFoldout);
            }

            return container;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (property.propertyType != SerializedPropertyType.ManagedReference) {
                EditorGUI.LabelField(position, label.text, "[SerializeReference] required");
                return;
            }

            float lineHeight = EditorGUIUtility.singleLineHeight;

            Rect btnRect = new(position.position.x, position.position.y, position.width, lineHeight);

            string typeName = property.managedReferenceValue == null
                ? "Null"
                : property.managedReferenceValue.GetType().Name;

            if (EditorGUI.DropdownButton(btnRect, new GUIContent($"{label.text}: {typeName}"), FocusType.Keyboard)) {
                ShowSelectMenu(property);
            }

            if (property.managedReferenceValue != null) {
                Rect contentRect = new(
                    position.x,
                    position.y + lineHeight + 2,
                    position.width,
                    position.height - lineHeight - 2
                );

                EditorGUI.indentLevel++;
                EditorGUI.PropertyField(contentRect, property, true);
                EditorGUI.indentLevel--;
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            float height = EditorGUIUtility.singleLineHeight;

            if (property.propertyType == SerializedPropertyType.ManagedReference
                    && property.managedReferenceValue != null) {
                height += EditorGUI.GetPropertyHeight(property, true) + 2;
            }

            return height;
        }

        private void ShowSelectMenu(SerializedProperty property) {
            GenericMenu menu = new();

            foreach (Type type in GetTypes(GetPropertyType())) {
                menu.AddItem(new GUIContent(type != null ? type.Name : "Null"), false, () => {
                    property.serializedObject.Update();
                    property.managedReferenceValue = Activator.CreateInstance(type);
                    property.serializedObject.ApplyModifiedProperties();
                });
            }

            menu.ShowAsContext();
        }

        private List<Type> GetTypes(Type baseType) {
            if (_cache.ContainsKey(baseType)) {
                return _cache[baseType];
            }

            var derived = TypeCache.GetTypesDerivedFrom(baseType);

            List<Type> subclasses = new();
            foreach (Type type in derived) {
                if (!type.IsAbstract) {
                    subclasses.Add(type);
                }
            }

            subclasses.Add(null);

            _cache.Add(baseType, subclasses);

            return subclasses;
        }

        private Type GetPropertyType() {
            Type type = fieldInfo.FieldType;

            if (type.IsArray) {
                return type.GetElementType();
            }

            if (type.IsGenericType) {
                return type.GetGenericArguments()[0];
            }

            return type;
        }
    }

}
