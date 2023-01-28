using Switch_System.Animation_System;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine;

namespace Switch_System
{
        [RequireComponent(typeof(Collider))]
        [RequireComponent(typeof(SwitchPressAnimation))]
        public class SwitchBase : MonoBehaviour
        {

                [Header("ToggleGroup")]
                [Tooltip("Will find parent object with SwitchGroup script. If SwitchBase belongs to a SwitchGroup it becomes a Toggle type")]
                [SerializeField] private SwitchGroup _switchGroup;
                
                [Header("Recipe")]
                [Tooltip("Insert a ScriptableObject type of SwitchRecipe. Switch will be built based on the recipe")]
                [SerializeField] private SwitchRecipe _switchRecipe;

                [SerializeField] private SwitchType _switchType;
                [SerializeField] private SwitchToggle _switchToggle;
                [SerializeField] private SwitchControlType _switchControlType;
                [SerializeField] private SwitchSignalType _switchSignalType;
                [SerializeField] private SwitchState _switchState;
                [SerializeField] private SwitchLight _switchLight;


                [SerializeField] private bool _isActive;
                [SerializeField] private bool _isAbleToTurnItselfOff;
                
                [Header("Light")]
                [Tooltip("Will find child object with EmissiveObject script")]
                [SerializeField] private EmissiveObject _emissiveObject;
                [SerializeField] private Color _colorActive;
                [SerializeField] private Color _colorInactive;

                [Header("Animations")] 
                [SerializeField] private bool _isSwitchPressAnimationInUse;
                [SerializeField] private SwitchPressAnimation _switchPressAnimation;

                [SerializeField] private bool _isSwitchAnimatorInUse;
                [SerializeField] private Animator _switchAnimator;
                
                #region Constructors
                private void Awake()
                {
                        InitializeSwitchObjects();
                }

                private void Start()
                {
                        InitializeSwitchVariables();
                }

                private void OnValidate()
                {
                        InitializeSwitchObjects();
                        InitializeSwitchVariables();
                }
                private void InitializeSwitchObjects()
                {
                        SetSwitchGroup(GetComponentInParent<SwitchGroup>());
                        SetEmissiveObject(GetComponentInChildren<EmissiveObject>());
                        SetSwitchPressAnimation(GetComponent<SwitchPressAnimation>());
                        SetSwitchAnimator(GetComponentInChildren<Animator>());
                }

                private void InitializeSwitchVariables()
                {
                        SetSwitchType(GetSwitchRecipe().GetSwitchType());
                        
                        SetSwitchToggle(GetSwitchGroup() ? SwitchToggle.Toggle : GetSwitchRecipe().GetSwitchToggle());
                        SetSwitchControlType(GetSwitchRecipe().GetSwitchControlType());
                        SetSwitchSignalType(GetSwitchRecipe().GetSwitchSignalType());
                        SetSwitchState(GetSwitchRecipe().GetSwitchState());
                        UpdateAnimatorParameters();
                }
                #endregion

                #region Get

                public SwitchRecipe GetSwitchRecipe()
                {
                        return _switchRecipe;
                }

                public SwitchType GetSwitchType()
                {
                        return _switchType;
                }

                public SwitchToggle GetSwitchToggle()
                {
                        return _switchToggle;
                }

                public SwitchControlType GetSwitchControlType()
                {
                        return _switchControlType;
                }

                public SwitchSignalType GetSwitchSignalType()
                {
                        return _switchSignalType;
                }

                public SwitchState GetSwitchState()
                {
                        return _switchState;
                }

                public SwitchGroup GetSwitchGroup()
                {
                        return _switchGroup;
                }

                public bool GetIsActive()
                {
                        return _isActive;
                }

                public bool GetIsAbleToTurnItselfOff()
                {
                        return _isAbleToTurnItselfOff;
                }

                public EmissiveObject GetEmissiveObject()
                {
                        return _emissiveObject;
                }

                public Color GetColorActive()
                {
                        return _colorActive;
                }

                public Color GetColorInactive()
                {
                        return _colorInactive;
                }


                public SwitchPressAnimation GetSwitchPressAnimation()
                {
                        return _switchPressAnimation;
                }

                public Animator GetSwitchAnimator()
                {
                        return _switchAnimator;
                }
                #endregion

                #region Set

                public bool SetSwitchRecipe(SwitchRecipe switchRecipe)
                {
                        _switchRecipe = switchRecipe;
                        return true;
                }

                public bool SetSwitchType(SwitchType switchType)
                {
                        _switchType = switchType;
                        return true;
                }

                public bool SetSwitchToggle(SwitchToggle switchToggle)
                {
                        _switchToggle = switchToggle;
                        return true;
                }

                public bool SetSwitchControlType(SwitchControlType switchControlType)
                {
                        _switchControlType = switchControlType;
                        return true;
                }

                public bool SetSwitchSignalType(SwitchSignalType switchSignalType)
                {
                        _switchSignalType = switchSignalType;
                        return true;
                }

                public bool SetSwitchState(SwitchState switchState)
                {
                        _switchState = switchState;
                        return true;
                }

                public bool SetSwitchGroup(SwitchGroup switchGroup)
                {
                        _switchGroup = switchGroup;
                        return true;
                }

                public bool SetIsActive(bool isActive)
                {
                        _isActive = isActive;
                        return true;
                }

                public bool SetIsAbleToTurnItselfOff(bool isAbleToTurnItselfOff)
                {
                        _isAbleToTurnItselfOff = isAbleToTurnItselfOff;
                        return true;
                }

                public bool SetEmissiveObject(EmissiveObject emissiveObject)
                {
                        _emissiveObject = emissiveObject;
                        return true;
                }

                public bool SetColorActive(Color colorActive)
                {
                        _colorActive = colorActive;
                        return true;
                }

                public bool SetColorInactive(Color colorInactive)
                {
                        _colorInactive = colorInactive;
                        return true;
                }

                public bool SetSwitchPressAnimation(SwitchPressAnimation switchPressAnimation)
                {
                        _switchPressAnimation = switchPressAnimation;
                        return true;
                }

                public bool SetSwitchAnimator(Animator switchAnimator)
                {
                        _switchAnimator = switchAnimator;
                        return true;
                }

                #endregion

                public void UpdateSwitch(SwitchState switchState, bool isForced)
                {
                        if (!isForced)
                        {
                                if (GetSwitchState() == switchState)
                                {
                                        return;
                                }

                                if (!GetIsAbleToTurnItselfOff() && GetSwitchState() == SwitchState.Off)
                                {
                                        //TODO
                                        return;
                                }
                        }
                }



                public void OnSwitchPress()
                {
                        GetSwitchPressAnimation().PressedAnimation();
                }

                public void OnSwitchHeld()
                {
                        GetSwitchPressAnimation().HeldAnimation();
                }
                public void OnSwitchRelease()
                {
                        GetSwitchPressAnimation().ReleasedAnimation();
                        UpdateSwitchState();
                }

                private void UpdateSwitchState()
                {
                        if (GetSwitchState() == SwitchState.Broken)
                        {
                                return;
                        }

                        if (GetSwitchState() == SwitchState.Transitioning)
                        {
                                //TODO wait for completion or interrupt anyways. maybe entire thing should be coroutine
                        }

                        if (GetSwitchState() == SwitchState.Off)
                        {
                                if (GetSwitchToggle() == SwitchToggle.Toggle)
                                {
                                        UpdateSwitchGroup();
                                        return;
                                }

                                SetSwitchState(SwitchState.On);
                                UpdateAnimatorParameters();
                                return;
                        }

                        if (GetSwitchState() == SwitchState.On)
                        {
                                if (GetSwitchToggle() == SwitchToggle.Toggle)
                                {
                                        UpdateSwitchGroup();
                                        return;
                                }
                                
                                SetSwitchState(SwitchState.Off);
                                UpdateAnimatorParameters();
                        }
                }

                private void UpdateSwitchGroup()
                {
                        //TODO update all switches in the group and launch their animations and change their states
                        throw new System.NotImplementedException();
                }

                private void UpdateAnimatorParameters()
                {
                        if (GetSwitchAnimator() == null)
                        {
                                return;
                        }
                        GetSwitchAnimator().SetInteger("SwitchState",(int)GetSwitchState());
                }
        }
}
