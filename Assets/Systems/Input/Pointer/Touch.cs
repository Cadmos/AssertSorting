using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Input_System
{
    public class Touch
    {
        private Camera _camera;
        private Vector3 _worldPosition;
        private Vector3 _screenPosition;
        private Vector3 _cameraPosition;

        private float _cameraDistanceOffset;
        
        private Vector3 _startPosition;
        private Vector3 _lastPosition;
        private Vector3 _currentPosition;
        private Vector3 _newPosition;

        private bool _isStarted;
        private bool _isHeld;
        private bool _isReleased;
        private bool _isDragged;

        private TouchRay _touchRay;

        #region Constructors


        public void InitializeTouch(Camera camera)
        {
            SetCamera(camera);
            SetWorldPosition(Vector3.zero);
            SetScreenPosition(Vector3.zero);
            SetCameraPosition(camera.transform.position);
            SetCameraDistanceOffset(camera.farClipPlane);

            SetStartPosition(Vector3.zero);
            SetLastPosition(Vector3.zero);
            SetCurrentPosition(Vector3.zero);
            SetNewPosition(Vector3.zero);

            SetIsStarted(false);
            SetIsHeld(false);
            SetIsReleased(false);
            SetIsDragged(false);

            SetTouchRay(new TouchRay());
        }
        #endregion
        
        #region Get

        public Camera GetCamera()
        {
            return _camera;
        }
        public Vector3 GetWorldPosition()
        {
            return _worldPosition;
        }
        public Vector3 GetScreenPosition()
        {
            return _screenPosition;
        }
        public Vector3 GetCameraPosition()
        {
            return _cameraPosition;
        }

        public float GetCameraDistanceOffset()
        {
            return _cameraDistanceOffset;
        }
        public Vector3 GetStartPosition()
        {
            return _startPosition;
        }
        public Vector3 GetLastPosition()
        {
            return _lastPosition;
        }
        public Vector3 GetCurrentPosition()
        {
            return _currentPosition;
        }
        public Vector3 GetNewPosition()
        {
            return _newPosition;
        }
        public bool GetIsStarted()
        {
            return _isStarted;
        }

        public bool GetIsHeld()
        {
            return _isHeld;
        }

        public bool GetIsReleased()
        {
            return _isReleased;
        }

        public bool GetIsDragged()
        {
            return _isDragged;
        }

        public TouchRay GetTouchRay()
        {
            return _touchRay;
        }
        #endregion
        #region Set

        public bool SetCamera(Camera camera)
        {
            _camera = camera;
            return true;
        }
        public bool SetWorldPosition(Vector3 worldPosition)
        {
            _worldPosition = worldPosition;
            return true;
        }
        public bool SetScreenPosition(Vector3 screenPosition)
        {
            _screenPosition = screenPosition;
            return true;
        }
        public bool SetCameraPosition(Vector3 cameraPosition)
        {
            _cameraPosition = cameraPosition;
            return true;
        }
        public bool SetCameraDistanceOffset(float cameraDistanceOffset)
        {
            _cameraDistanceOffset = cameraDistanceOffset;
            return true;
        }
        public bool SetStartPosition(Vector3 startPosition)
        {
            _startPosition = startPosition;
            return true;
        }
        public bool SetLastPosition(Vector3 lastPosition)
        {
            _lastPosition = lastPosition;
            return true;
        }
        public bool SetCurrentPosition(Vector3 currentPosition)
        {
            _currentPosition = currentPosition;
            return true;
        }
        public bool SetNewPosition(Vector3 newPosition)
        {
            _newPosition = newPosition;
            return true;
        }
        
        public bool SetIsStarted(bool isStarted)
        {
            _isStarted = isStarted;
            return true;
        }

        public bool SetIsHeld(bool isHeld)
        {
            _isHeld = isHeld;
            return true;
        }

        public bool SetIsReleased(bool isReleased)
        {
            _isReleased = isReleased;
            return true;
        }

        public bool SetIsDragged(bool isDragged)
        {
            _isDragged = isDragged;
            return true;
        }

        public bool SetTouchRay(TouchRay touchRay)
        {
            _touchRay = touchRay;
            return true;
        }
        #endregion

        public void CalculateScreenPosition()
        {
            
        }

        public void CalculateWorldPosition()
        {
            SetWorldPosition(GetCamera().ScreenToWorldPoint(GetScreenPosition()));
        }


        public void UpdateTouchRay()
        {
            GetTouchRay().SetRayOrigin(GetCameraPosition());
            GetTouchRay().SetRayDirection(GetWorldPosition() - GetCameraPosition());
            GetTouchRay().SetRayLength(GetCameraDistanceOffset());
        }

        public RaycastHit FireTouchPhysicsRaycast()
        {
            //GetTouchRay().DrawRaycast();
            return GetTouchRay().TouchRayCast();
        }
    }
}


