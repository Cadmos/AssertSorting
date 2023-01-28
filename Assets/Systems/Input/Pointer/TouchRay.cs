using Debug_System;
using UnityEngine;

namespace Input_System
{
    public class TouchRay
    {
        private LayerMask _rayLayerMask;
        private Vector3 _rayOrigin;
        private Vector3 _rayDirection;
        private float _rayLength;
        private bool _isRayActive;
        
        private Ray _touchRay;

        
        
        #region Constructors

        public void InitializeTouchRay(LayerMask rayLayerMask)
        {
            SetRayLayerMask(rayLayerMask);
            SetRayOrigin(Vector3.zero);
            SetRayDirection(Vector3.zero);
            SetRayLength(0);
            SetIsRayActive(false);
        }

        public void UpdateRay()
        {
            SetTouchRay(new Ray(GetRayOrigin(), GetRayDirection()));
        }

        #endregion
        
        #region Get

        public Vector3 GetRayOrigin()
        {
            return _rayOrigin;
        }
        public Vector3 GetRayDirection()
        {
            return _rayDirection;
        }
        public float GetRayLength()
        {
            return _rayLength;
        }
        public bool GetIsRayActive()
        {
            return _isRayActive;
        }

        public LayerMask GetRayLayerMask()
        {
            return _rayLayerMask;
        }
        public Ray GetTouchRay()
        {
            return _touchRay;
        }
        #endregion

        #region Set

        public bool SetRayOrigin(Vector3 rayOrigin)
        {
            _rayOrigin = rayOrigin;
            return true;
        }
        public bool SetRayDirection(Vector3 rayDirection)
        {
            _rayDirection = rayDirection;
            return true;
        }
        public bool SetRayLength(float rayLength)
        {
            _rayLength = rayLength;
            return true;
        }
        public bool SetIsRayActive(bool isRayActive)
        {
            _isRayActive = isRayActive;
            return true;
        }

        public bool SetRayLayerMask(LayerMask rayLayerMask)
        {
            _rayLayerMask = rayLayerMask;
            return true;
        }
        public bool SetTouchRay(Ray touchRay)
        {
            _touchRay = touchRay;
            return true;
        }
        
        #endregion

        public RaycastHit TouchRayCast()
        {
            Physics.Raycast(GetRayOrigin(), GetRayDirection(), out RaycastHit hitInfo, GetRayLength(), GetRayLayerMask());
            return hitInfo;
        }

        public void DrawRaycast()
        {
            Debug.DrawRay(GetRayOrigin(), GetRayDirection(),Color.magenta,10);
        }
    }
}