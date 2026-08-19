using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WorldLightTransition))]
public class WorldLightTransition_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WorldLightTransition myScript = (WorldLightTransition)target;
        if (GUILayout.Button("Change Light"))
        {
            myScript.ChangeLight();
        }
    }
}
