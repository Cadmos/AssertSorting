using System;
using UnityEngine;

namespace Switch_System
{
    [Serializable]
    public class ObjectBuilderPart
    {
        [SerializeField] private ObjectBuilderPartSO _objectBuilderPartRecipe;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private string _gameObjectName;
        private Transform _transform;
        
        private MeshFilter _meshFilter;
        private MeshRenderer _meshRenderer;
        
        [SerializeField] private Mesh _sharedMesh;
        [SerializeField] private Material _sharedMaterial;
        
        [SerializeField] private bool _isStatic;
        [SerializeField] private string _layerName;
        [SerializeField] private bool _isActive;

        #region Get

        public ObjectBuilderPartSO GetObjectBuilderPartRecipe()
        {
            return _objectBuilderPartRecipe;
        }
        public GameObject GetGameObject()
        {
            return _gameObject;
        }

        public string GetGameObjectName()
        {
            return _gameObjectName;
        }

        public Transform GetTransform()
        {
            return _transform;
        }

        public MeshFilter GetMeshFilter()
        {
            return _meshFilter;
        }

        public MeshRenderer GetMeshRenderer()
        {
            return _meshRenderer;
        }

        public Mesh GetSharedMesh()
        {
            return _sharedMesh;
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

        public bool GetIsActive()
        {
            return _isActive;
        }

        #endregion
        #region Set

        public bool SetObjectBuilderRecipe(ObjectBuilderPartSO objectBuilderPartRecipe)
        {
            _objectBuilderPartRecipe = objectBuilderPartRecipe;
            return true;
        }
        public bool SetGameObject(GameObject gameObject)
        {
            _gameObject = gameObject;
            return true;
        }

        public bool SetGameObjectName(string gameObjectName)
        {
            _gameObjectName = gameObjectName;
            return true;
        }

        public bool SetTransform(Transform transform)
        {
            _transform = transform;
            return true;
        }

        public bool SetMeshFilter(MeshFilter meshFilter)
        {
            _meshFilter = meshFilter;
            return true;
        }

        public bool SetMeshRenderer(MeshRenderer meshRenderer)
        {
            _meshRenderer = meshRenderer;
            return true;
        }

        public bool SetSharedMesh(Mesh sharedMesh)
        {
            _sharedMesh = sharedMesh;
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

        public bool SetIsActive(bool isActive)
        {
            _isActive = isActive;
            return true;
        }

        #endregion

        public void InitializeGameObject(Transform transform)
        {
            ReadScriptableObject(transform);
            
            CreateNewGameObject();
            
            AddComponentsToGameObject();
            
            GetComponentsFromGameObject();
            
            UpdateGameObject();
        }
        
        public void ReadScriptableObject(Transform transform)
        {
            if (GetObjectBuilderPartRecipe() == null) return;
            SetTransform(transform);
            SetGameObjectName(GetObjectBuilderPartRecipe().GetGameObjectName());
            SetLayerName(GetObjectBuilderPartRecipe().GetLayerName());
 
            SetSharedMaterial(GetObjectBuilderPartRecipe().GetSharedMaterial());
            
            SetSharedMesh(GetObjectBuilderPartRecipe().GetSharedMesh());
            SetIsActive(GetObjectBuilderPartRecipe().GetIsActive());
            SetIsStatic(GetObjectBuilderPartRecipe().GetIsActive());
        }

        public void CreateNewGameObject()
        {
            if (GetGameObject() != null) return;
            
            SetGameObject(new GameObject());

        }

        public void AddComponentsToGameObject()
        {
            if (GetGameObject() == null) return;

            if (GetMeshRenderer() == null)
            {
                GetGameObject().AddComponent<MeshRenderer>();
            }
            if (GetMeshFilter() == null)
            {
                GetGameObject().AddComponent<MeshFilter>();
            }
        }

        public void GetComponentsFromGameObject()
        {
            if (GetGameObject() == null) return;
            
            SetMeshRenderer(GetGameObject().GetComponent<MeshRenderer>());
            SetMeshFilter(GetGameObject().GetComponent<MeshFilter>());
        }

        public void UpdateGameObject()
        {
            if (GetGameObject() == null) return;
            
            if (GetMeshRenderer() == null) return;
            
            if (GetMeshFilter() == null) return;
            
            GetGameObject().name = GetGameObjectName();
            GetGameObject().transform.parent = GetTransform();
            GetGameObject().transform.SetPositionAndRotation(GetTransform().position, GetTransform().rotation);
            GetGameObject().layer = LayerMask.NameToLayer(GetLayerName());
            GetGameObject().isStatic = GetIsStatic();
            GetGameObject().SetActive(GetIsActive());
            
            GetMeshFilter().sharedMesh = GetSharedMesh();
            GetMeshRenderer().sharedMaterial = GetSharedMaterial();
        }
    }
}