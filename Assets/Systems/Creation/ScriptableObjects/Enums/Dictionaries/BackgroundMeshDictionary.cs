using System;
using System.Collections.Generic;
using UnityEngine;

namespace Switch_System.Creation_System.ScriptableObjects.Enums.Dictionaries
{
    [CreateAssetMenu(fileName = "MeshTypeName", menuName = "ScriptableObjects/Dictionary/Switch/Mesh/Background", order = 4)]
    public class BackgroundMeshDictionary : ScriptableObject
    {
        public List<BackgroundMeshEnumLink> _meshEnumLinks;
    }


    [Serializable]
    public class BackgroundMeshEnumLink
    {
        public BackgroundMeshEnumValue type;
        public Mesh mesh;
    }
}
