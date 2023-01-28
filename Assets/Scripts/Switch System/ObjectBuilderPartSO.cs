using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Switch_System
{
    [CreateAssetMenu(fileName = "ObjectRecipe", menuName = "ScriptableObjects/Recipes/ObjectPart")]
    public class ObjectBuilderPartSO : ScriptableObject
    {
        [SerializeField] private string _gameObjectName;
        [SerializeField] private Mesh _mesh;
        [SerializeField] private Mesh _sharedMesh;
        [SerializeField] private Material _material;
        [SerializeField] private Material _sharedMaterial;
        [SerializeField] private bool _isStatic;
        [SerializeField] private string _layerName;
        [SerializeField] private int _layer;
        [SerializeField] private bool _isActive;

        #region Get

        public string GetGameObjectName()
        {
            return _gameObjectName;
        }

        public Mesh GetMesh()
        {
            return _mesh;
        }
        public Mesh GetSharedMesh()
        {
            return _sharedMesh;
        }
        public Material GetMaterial()
        {
            return _material;
        }

        public Material GetSharedMaterial()
        {
            return _sharedMaterial;
        }

        public bool GetIsStatic()
        {
            return _isStatic;
        }
        public string GetLayerName()
        {
            return _layerName;
        }

        public int GetLayer()
        {
            return _layer;
        }

        public bool GetIsActive()
        {
            return _isActive;
        }

        #endregion

        #region Set

        public bool SetGameObjectName(string gameObjectName)
        {
            _gameObjectName = gameObjectName;
            return true;
        }
        public bool SetMesh(Mesh mesh)
        {
            _mesh = mesh;
            return true;
        }

        public bool SetSharedMesh(Mesh sharedMesh)
        {
            _sharedMesh = sharedMesh;
            return true;
        }

        public bool SetMaterial(Material material)
        {
            _material = material;
            return true;
        }

        public bool SetSharedMaterial(Material sharedMaterial)
        {
            _sharedMaterial = sharedMaterial;
            return true;
        }

        public bool SetIsStatic(bool isStatic)
        {
            _isStatic = isStatic;
            return true;
        }

        public bool SetLayerName(string layerName)
        {
            _layerName = layerName;
            return true;
        }

        public bool SetLayer(int layer)
        {
            _layer = layer;
            return true;
        }

        public bool SetIsActive(bool isActive)
        {
            _isActive = isActive;
            return true;
        }
        #endregion
    }
}