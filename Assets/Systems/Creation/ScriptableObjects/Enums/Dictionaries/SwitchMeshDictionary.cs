using System;
using System.Collections.Generic;
using UnityEngine;

namespace Switch_System.Creation_System.ScriptableObjects.Enums.Dictionaries
{
    [CreateAssetMenu(fileName = "MeshTypeName", menuName = "ScriptableObjects/Dictionary/Switch/Mesh/Switch", order = 4)]
    public class SwitchMeshDictionary : ScriptableObject
    {
        public List<SwitchMeshEnumLink> _meshEnumLinks;
    }


    [Serializable]
    public class SwitchMeshEnumLink
    {
        public SwitchMeshEnumValue type;
        public Mesh mesh;
    }
}
