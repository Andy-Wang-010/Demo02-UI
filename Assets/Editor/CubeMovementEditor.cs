#if false  // Disable the class until we are ready to use it

using UnityEditor;
using UnityEngine;

namespace Editor
{
    // Mark this class as a custom editor for "CubeMovement" components
    [CustomEditor(typeof(CubeMovement))]
    public class CubeMovementEditor : UnityEditor.Editor
    {
        // Called when drawing the inspector
        public override void OnInspectorGUI()
        {
            // Draws default properties
            base.OnInspectorGUI();
            EditorGUILayout.Space(16);
            
            // Relevant classes:
            //    GUI
            //    GUILayout
            //    EditorGUI
            //    EditorGUILayout
            
            EditorGUILayout.LabelField("Hello!");

            if (GUILayout.Button("Press Me"))
            {
                Debug.Log("Button was pressed");
            }
            
            
        }
    }
}

#endif