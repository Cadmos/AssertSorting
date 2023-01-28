using System;
using Switch_System.Creation_System.ScriptableObjects.Enums;
using Switch_System.Creation_System.ScriptableObjects.Enums.Dictionaries;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

[CustomEditor(typeof(SwitchBuilder))]
public class SwitchBuilderEditor : Editor
{
    private bool _isRecipeChosen;

    
    
    private Mesh _mesh1;
    private Mesh _mesh2;
    private Mesh _mesh3;

    private Material _material1;
    private Material _material2;
    private Material _material3;

    
    
    
    
    
    

    private void OnEnable()
    {
        
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        SwitchBuilder switchBuilder = (SwitchBuilder)target;
        
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("GetSwitchRecipe()"));


        EditorGUILayout.PropertyField(serializedObject.FindProperty("_switchType"));
    }


/*
    private void InstantiateFrameMesh(FrameMeshEnumValue frameMeshEnumValue)
    {
        switch (frameMeshEnumValue)
        {
            case 0:
                Debug.LogWarning(this + "hasnt been initialized");
                break;
            case 1:
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = Vector3.zero;
                break;
            case 2:
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                plane.transform.position = Vector3.zero;
                break;
            default:
                Debug.LogError("Unrecognized Option");
                break;
        }
    }
    */
}
