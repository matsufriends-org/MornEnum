#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace MornEnum
{
    public abstract class MornEnumDrawerBase : PropertyDrawer
    {
        protected abstract string[] Values { get; }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var keyProperty = property.FindPropertyRelative("_key");
            if (keyProperty == null || keyProperty.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.PropertyField(position, property, label, true);
                return;
            }

            EditorGUI.BeginProperty(position, label, property);
            {
                var key = keyProperty.stringValue;
                var selectedIndex = Array.IndexOf(Values, key);
                
                if (Values.Length > 0)
                {
                    if (selectedIndex < 0)
                    {
                        selectedIndex = 0;
                        keyProperty.stringValue = Values[selectedIndex];
                    }
                    else
                    {
                        selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, Values);
                        keyProperty.stringValue = Values[selectedIndex];
                    }
                }
                else
                {
                    EditorGUI.LabelField(position, label.text, "No Values");
                    return;
                }   
            }
            EditorGUI.EndProperty();
            
            property.serializedObject.ApplyModifiedProperties();
            property.serializedObject.Update();
        }
    }
}
#endif