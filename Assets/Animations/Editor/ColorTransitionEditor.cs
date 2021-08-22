using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using static ColorTransition;

[CustomEditor(typeof(ColorTransition))]
public class ColorTransitionEditor : Editor
{
    private FieldInfo _bindingModeField;
    private ColorFieldArtist _startColor;
    private ColorFieldArtist _endColor;

    internal static FieldInfo GetField<T>(string fieldName)
    {
        BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Static;
        return typeof(T).GetField(fieldName, bindFlags);
    }

    private void OnEnable()
    {
        _bindingModeField = GetField<ColorTransition>("_colorBinding");
        _startColor = new ColorFieldArtist { source = target, colorProperty = GetField<ColorTransition>("_startColor"), propertyName = "Start Color" };
        _endColor = new ColorFieldArtist { source = target, colorProperty = GetField<ColorTransition>("_endColor"), propertyName = "End Color" };
    }

    public override void OnInspectorGUI()
    {
        ColorBinding bindingMode = (ColorBinding)_bindingModeField.GetValue(target);
        switch (bindingMode)
        {
            case ColorBinding.None:
                _startColor.Draw();
                _endColor.Draw();
                break;
            case ColorBinding.Start:
                _endColor.Draw();
                break;
            case ColorBinding.End:
                _startColor.Draw();
                break;
        }
        DrawDefaultInspector();
    }

    class ColorFieldArtist
    {
        public UnityEngine.Object source;
        public FieldInfo colorProperty;
        public string propertyName;

        public void Draw()
        {
            colorProperty.SetValue(source, EditorGUILayout.ColorField(propertyName, (Color)colorProperty.GetValue(source)));
        }
    }

    
}
