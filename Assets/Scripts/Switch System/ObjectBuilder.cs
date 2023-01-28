using UnityEngine;

namespace Switch_System
{
    public class ObjectBuilder : MonoBehaviour
    {
        [SerializeField] private bool _interactable;
        [SerializeField] private ObjectBuilderParts _objectBuilderParts;
        [SerializeField] private ObjectBuilderPart _objectBuilderPart;
        [SerializeField] private GameObject _parentGameObject;
        [SerializeField] private Transform _transform;

        
        public bool GetInteractable()
        {
            return _interactable;
        }

        public ObjectBuilderParts GetObjectBuilderParts()
        {
            return _objectBuilderParts;
        }
        public ObjectBuilderPart GetObjectBuilderPart()
        {
            return _objectBuilderPart;
        }

        public GameObject GetParentGameObject()
        {
            return _parentGameObject;
        }

        public Transform GetTransform()
        {
            return _transform;
        }


        public bool SetInteractable(bool interactable)
        {
            _interactable = interactable;
            return true;
        }

        public bool SetObjectBuilderParts(ObjectBuilderParts objectBuilderParts)
        {
            _objectBuilderParts = objectBuilderParts;
            return true;
        }
        
        public bool SetObjectBuilderPart(ObjectBuilderPart objectBuilderPart)
        {
            _objectBuilderPart = objectBuilderPart;
            return true;
        }

        public bool SetParentGameObject(GameObject parentGameObject)
        {
            _parentGameObject = parentGameObject;
            return true;
        }

        public bool SetTransform(Transform transform)
        {
            _transform = transform;
            return true;
        }
        
        public void UpdateGameObject()
        {
            SetParentGameObject(gameObject);
            SetTransform(transform);
        }

        public void InitializeGameObject()
        {
            if (GetTransform() == null)
            {
                UpdateGameObject();
            }
            GetObjectBuilderPart().InitializeGameObject(GetTransform());
        }

    }
}