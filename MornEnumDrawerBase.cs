#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace MornEnum
{
    public abstract class MornEnumDrawerBase<T> : PropertyDrawer where T : MornEnumGlobalBase<T>
    {
        protected abstract T Global { get; }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (Global == null)
            {
                EditorGUI.LabelField(position, label.text, "Global is null");
                return;
            }
            
            EditorGUI.BeginProperty(position, label, property);
            {
                var keyProperty = property.FindPropertyRelative("_key");
                var flags = Global.Flags;
                var selectedIndex = flags.IndexOf(keyProperty.stringValue);
                // 選択されていない場合は0にする 
                if (selectedIndex == -1)
                {
                    selectedIndex = 0;
                }

                selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, flags.ToArray());
                keyProperty.stringValue = flags[selectedIndex];
            }
            EditorGUI.EndProperty();
        }
    }
}
#endif