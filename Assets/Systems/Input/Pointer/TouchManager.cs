using System.Collections;
using Debug_System;
using Switch_System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input_System
{

    public class TouchManager : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;

        private PlayerInput _playerInput;
        private InputAction _touchPressAction;
        private InputAction _touchPositionAction;

        
        private SwitchBase _pressedSwitch;
        private SwitchBase _lastPressedSwitch;

        private GameObject _lastGameObject;

        private Touch _touch;


        [SerializeField] private Camera _camera;

        #region Constructors
        #endregion
        
        #region Get

        public PlayerInput GetPlayerInput()
        {
            return _playerInput;
        }

        public InputAction GetTouchPressAction()
        {
            return _touchPressAction;
        }

        public InputAction GetTouchPositionAction()
        {
            return _touchPositionAction;
        }

        public SwitchBase GetPressedSwitch()
        {
            return _pressedSwitch;
        }
        public LayerMask GetLayerMask()
        {
            return _layerMask;
        }
        public Touch GetTouch()
        {
            return _touch;
        }
        #endregion

        #region Set

        public bool SetPlayerInput(PlayerInput playerInput)
        {
            _playerInput = playerInput;
            return true;
        }
        public bool SetTouchPressAction(InputAction touchPressAction)
        {
            _touchPressAction = touchPressAction;
            return true;
        }
        public bool SetTouchPositionAction(InputAction touchPositionAction)
        {
            _touchPositionAction = touchPositionAction;
            return true;
        }
        public bool SetPressedSwitch(SwitchBase pressedSwitch)
        {
            _pressedSwitch = pressedSwitch;
            return true;
        }
        public bool SetLayerMask(LayerMask layerMask)
        {
            _layerMask = layerMask;
            return true;
        }
        public bool SetTouch(Touch touch)
        {
            _touch = touch;
            return true;
        }
        
        

        #endregion
        private void Awake()
        {
            InitializeObjects();
        }

        public void InitializeObjects()
        {
            _camera = Camera.main;
            SetPlayerInput(GetComponent<PlayerInput>());
            SetTouchPressAction(GetPlayerInput().actions.FindAction("TouchPress"));
            SetTouch(new Touch());
        }

        private void OnEnable()
        {
            GetTouchPressAction().started += TouchPressed;
            GetTouchPressAction().performed += TouchHeld;
            GetTouchPressAction().canceled += TouchReleased;
        }
        
        private void Start()
        {
            InitializeVariables();
        }

        public void InitializeVariables()
        {
            
            GetTouch().InitializeTouch(_camera);
            GetTouch().GetTouchRay().InitializeTouchRay(GetLayerMask());
            }



        private void OnDisable()
        {
            GetTouchPressAction().started -= TouchPressed;
            GetTouchPressAction().performed -= TouchHeld;
            GetTouchPressAction().canceled -= TouchReleased;
        }




        public void TouchPressed(InputAction.CallbackContext context)
        {
            ButtonLogic();
        }



        public void TouchHeld(InputAction.CallbackContext context)
        {
            ButtonLogic();
        }

        
        
        public void TouchReleased(InputAction.CallbackContext context)
        {
            ButtonLogic();
        }

        private void JoystickLogic()
        {
            UpdateTouchPositions();
            GetTouch().UpdateTouchRay();

            RaycastHit hitInfo;
            if (Physics.Raycast(GetTouch().GetTouchRay().GetRayOrigin(), GetTouch().GetTouchRay().GetRayDirection(), out hitInfo, GetTouch().GetTouchRay().GetRayLength(), GetTouch().GetTouchRay().GetRayLayerMask()))
            {
                GameObject transformGameObject = hitInfo.transform.gameObject;

                SwitchBase switchBase;
                if (transformGameObject.TryGetComponent(out switchBase))
                {
                    
                }
            }
            
        }
        private void ButtonLogic()
        {
            UpdateTouchPositions();
            GetTouch().UpdateTouchRay();
            
            RaycastHit hitInfo;
            Debug.DrawRay(GetTouch().GetTouchRay().GetRayOrigin(), GetTouch().GetTouchRay().GetRayDirection(), Color.magenta, 10);

            if (Physics.Raycast(GetTouch().GetTouchRay().GetRayOrigin(), GetTouch().GetTouchRay().GetRayDirection(), out hitInfo, GetTouch().GetTouchRay().GetRayLength(), GetTouch().GetTouchRay().GetRayLayerMask()))
            {
                GameObject transformGameObject = hitInfo.transform.gameObject;

                SwitchBase switchBase;

                if (transformGameObject.TryGetComponent<SwitchBase>(out switchBase))
                {
                    if (_lastPressedSwitch == null)
                    {
                        switchBase.OnSwitchPress();
                        _lastPressedSwitch = switchBase;
                        return;
                    }

                    if (_lastPressedSwitch.GetInstanceID() != switchBase.GetInstanceID())
                    {
                        _lastPressedSwitch.OnSwitchRelease();
                        _lastPressedSwitch = null;
                    }
                    else
                    {
                        switchBase.OnSwitchHeld();
                        _lastPressedSwitch = switchBase;
                    }
                }
            }
            else
            {
                if (_lastPressedSwitch != null)
                {
                    _lastPressedSwitch.OnSwitchRelease();
                    _lastPressedSwitch = null;
                }
            }
        }

        private void UpdateTouchPositions()
        { 
            GetTouch().SetScreenPosition(new Vector3(GetTouchPressAction().ReadValue<Vector2>().x,GetTouchPressAction().ReadValue<Vector2>().y, GetTouch().GetCameraDistanceOffset()));
            Debug.Log(GetTouchPressAction().ReadValue<Vector2>());
            GetTouch().CalculateWorldPosition();
            DebugSystem.Instance.WriteToTextMesh($"worldPos {GetTouch().GetWorldPosition()}, origin: {GetTouch().GetTouchRay().GetRayOrigin()}, dir:{GetTouch().GetTouchRay().GetRayOrigin()} ");
        }

        private IEnumerator Hold()
        {
            GetTouch().SetIsDragged(true);
            while (GetTouch().GetIsDragged())
            {
                UpdateTouchPositions();
                GetTouch().UpdateTouchRay();
                SwitchBase switchBase = DoRaycast();
                DebugSystem.Instance.WriteToTextMesh($"worldPos {GetTouch().GetWorldPosition()}, obj: {switchBase} ");
                switchBase.OnSwitchHeld();
                yield return null;
            }
        }
        

        private SwitchBase DoRaycast()
        {
            RaycastHit hitInfo = GetTouch().FireTouchPhysicsRaycast();
            GameObject transformGameObject = hitInfo.transform.gameObject;
            return transformGameObject.GetComponent<SwitchBase>();
        }
    }
}