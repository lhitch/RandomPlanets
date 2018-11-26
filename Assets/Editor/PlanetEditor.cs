using UnityEngine;
using System.Collections;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor {

    Planet planet;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DrawSettingsEditor(planet.shapeSettings);
        DrawSettingsEditor(planet.colorSettings);
    }

    void DrawSettingsEditor(Object settings)
    {
        TextEditor editor = CreateEditor(settings);
        editor.OnInspectorGUI();
    }

    private void OnEnable()
    {
        planet = (Planet)target;
    }
}
