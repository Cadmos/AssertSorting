using UnityEditor;
using UnityEngine;

namespace Switch_System
{
    [CustomEditor(typeof(ObjectBuilder))]
    public class ObjectBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            ObjectBuilder objectBuilder = (ObjectBuilder)target;
            objectBuilder.UpdateGameObject();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("_interactable"));

            

            if (objectBuilder.GetInteractable())
            {
                if(GUILayout.Button("InitializeGameObject"))
                {
                    objectBuilder.InitializeGameObject();
                }
                EditorGUILayout.PropertyField(serializedObject.FindProperty("_objectBuilderPart"));
            }
            else
            {
                EditorGUILayout.Slider(1, 0, 3);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}