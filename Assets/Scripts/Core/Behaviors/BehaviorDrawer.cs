#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BaseBehavior))]
public class BehaviorDrawer : PropertyDrawer
{
    private static Dictionary<string, Type> _types;
    private static string[] _typeNames;

    static BehaviorDrawer()
    {
        var baseType = typeof(BaseBehavior);

        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => !t.IsAbstract && baseType.IsAssignableFrom(t))
            .ToList();

        _types = types.ToDictionary(t => t.FullName, t => t);
        _typeNames = types.Select(t => t.Name).ToArray();
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var typeRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

        string currentTypeName = null;

        if (property.managedReferenceValue != null)
            currentTypeName = property.managedReferenceValue.GetType().FullName;

        int currentIndex = -1;

        if (currentTypeName != null)
        {
            var keys = _types.Keys.ToArray();
            currentIndex = Array.IndexOf(keys, currentTypeName);
        }

        int selectedIndex = EditorGUI.Popup(typeRect, label.text, currentIndex, _typeNames);

        if (selectedIndex != currentIndex)
        {
            var selectedType = _types.Values.ElementAt(selectedIndex);
            property.managedReferenceValue = Activator.CreateInstance(selectedType);
        }

        if (property.managedReferenceValue != null)
        {
            var propertyRect = new Rect(
                position.x,
                position.y + EditorGUIUtility.singleLineHeight + 2,
                position.width,
                EditorGUI.GetPropertyHeight(property, true));

            EditorGUI.indentLevel++;
            EditorGUI.PropertyField(propertyRect, property, true);
            EditorGUI.indentLevel--;
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.managedReferenceValue == null)
            return EditorGUIUtility.singleLineHeight;

        return EditorGUIUtility.singleLineHeight +
               EditorGUI.GetPropertyHeight(property, true) + 4;
    }
}
#endif