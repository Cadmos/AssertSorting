using System;
using Switch_System.Animation_System;
using Switch_System.Creation_System.ScriptableObjects.Enums;
using Switch_System.Creation_System.ScriptableObjects.Enums.Dictionaries;
using UnityEngine;

namespace Switch_System
{
        [CreateAssetMenu(fileName = "SwitchScriptableObject", menuName = "ScriptableObjects/SwitchRecipe")]
        public class SwitchRecipe : ScriptableObject
        {
                [Header("Functionality")] 
                
                [SerializeField] private SwitchType _switchType;
                [SerializeField] private SwitchToggle _switchToggle;
                [SerializeField] private SwitchControlType _switchControlType;
                [SerializeField] private SwitchSignalType _switchSignalType;
                [SerializeField] private SwitchState _switchState;

                [Header("Indicators")]
                [SerializeField] private SwitchLight _switchLight;
                
                [Header("Light")]
                [Tooltip("Will find child object with EmissiveObject script")]
                [SerializeField] private EmissiveObject _emissiveObject;
                [SerializeField] private Color _colorActive;
                [SerializeField] private Color _colorInactive;
                
                
                [Header("Graphics")] 
                [SerializeField] private FrameMeshEnumValue _chosenFrameMeshEnumValue;
                [SerializeField] private Material _frameMaterial;
                
                
                [SerializeField] private BackgroundMeshDictionary _meshDictionary;
                [SerializeField] private BackgroundMeshEnumValue _chosenBackgroundMeshEnumValue;
                [SerializeField] private Material _backgroundMaterial;
                
                [SerializeField] private ImageMeshEnumValue _chosenImageMeshEnumValue;
                [SerializeField] private Material _imageMaterial;
                [SerializeField] private Texture _imageTexture;
                
                [SerializeField] private CoverMeshEnumValue _chosenCoverMeshEnumValue;
                [SerializeField] private Material _coverMaterial;

                [SerializeField] private SwitchMeshEnumValue _chosenSwitchMeshEnumValue;
                [SerializeField] private Material _switchMaterial;
                
                [SerializeField] private LabelMeshEnumValue _chosenLabelMeshEnumValue;
                [SerializeField] private string _labelText;

                
                [Header("Animations")]
                [SerializeField] private bool _isSwitchPressAnimationInUse;
                [SerializeField] private SwitchPressAnimation _switchPressAnimation;
                
                [SerializeField] private bool _isSwitchAnimatorInUse;
                [SerializeField] private Animator _switchAnimator;
                /*TODO
                [Header("Library Management")] [SerializeField]
                private BackgroundMeshDictionary _backgroundMeshDictionary;
                */

                private void OnValidate()
                {
                        InitializeRecipe();
                }

                #region Constructors

                public void InitializeRecipe()
                {
                }

                #endregion

                #region Get

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

                public SwitchLight GetSwitchLight()
                {
                        return _switchLight;
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

                public FrameMeshEnumValue GetChosenFrameMeshEnumValue()
                {
                        return _chosenFrameMeshEnumValue;
                }

                public Material GetFrameMaterial()
                {
                        return _frameMaterial;
                }
                
                public BackgroundMeshEnumValue GetChosenBackgroundMeshEnumValue()
                {
                        return _chosenBackgroundMeshEnumValue;
                }

                public Material GetBackgroundMaterial()
                {
                        return _backgroundMaterial;
                }

                public ImageMeshEnumValue GetChosenImageMeshEnumValue()
                {
                        return _chosenImageMeshEnumValue;
                }

                public Material GetImageMaterial()
                {
                        return _imageMaterial;
                }

                public Texture GetImageTexture()
                {
                        return _imageTexture;
                }
                public CoverMeshEnumValue GetChosenCoverMeshEnumValue()
                {
                        return _chosenCoverMeshEnumValue;
                }

                public Material GetCoverMaterial()
                {
                        return _coverMaterial;
                }
                
                public SwitchMeshEnumValue GetSwitchFrameMeshEnumValue()
                {
                        return _chosenSwitchMeshEnumValue;
                }

                public Material GetSwitchMaterial()
                {
                        return _switchMaterial;
                }
                
                public LabelMeshEnumValue GetChosenLabelMeshEnumValue()
                {
                        return _chosenLabelMeshEnumValue;
                }

                public string GetLabelText()
                {
                        return _labelText;
                }

                public bool GetIsSwitchPressAnimationInUse()
                {
                        return _isSwitchPressAnimationInUse;
                }

                public SwitchPressAnimation GetSwitchPressAnimation()
                {
                        return _switchPressAnimation;
                }
                
                public bool GetIsSwitchAnimatorInUse()
                {
                        return _isSwitchAnimatorInUse;
                }

                public Animator GetSwitchAnimator()
                {
                        return _switchAnimator;
                }

                #endregion

                #region Set

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

                public bool SetSwitchLight(SwitchLight switchLight)
                {
                        _switchLight = switchLight;
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

                public bool SetFrameMeshEnumValue(FrameMeshEnumValue chosenFrameMeshEnumValue)
                {
                        _chosenFrameMeshEnumValue = chosenFrameMeshEnumValue;
                        return true;
                }

                public bool SetFrameMaterial(Material frameMaterial)
                {
                        _frameMaterial = frameMaterial;
                        return true;
                }
                public bool SetBackgroundMeshEnumValue(BackgroundMeshEnumValue chosenBackgroundMeshEnumValue)
                {
                        _chosenBackgroundMeshEnumValue = chosenBackgroundMeshEnumValue;
                        return true;
                }

                public bool SetBackgroundMaterial(Material backgroundMaterial)
                {
                        _backgroundMaterial = backgroundMaterial;
                        return true;
                }
                public bool SetImageMeshEnumValue(ImageMeshEnumValue chosenImageMeshEnumValue)
                {
                        _chosenImageMeshEnumValue = chosenImageMeshEnumValue;
                        return true;
                }

                public bool SetImageMaterial(Material imageMaterial)
                {
                        _imageMaterial = imageMaterial;
                        return true;
                }

                public bool SetImageTexture(Texture imageTexture)
                {
                        _imageTexture = imageTexture;
                        return true;
                }
                public bool SetCoverMeshEnumValue(CoverMeshEnumValue chosenCoverMeshEnumValue)
                {
                        _chosenCoverMeshEnumValue = chosenCoverMeshEnumValue;
                        return true;
                }

                public bool SetCoverMaterial(Material coverMaterial)
                {
                        _coverMaterial = coverMaterial;
                        return true;
                }
                
                public bool SetSwitchMeshEnumValue(SwitchMeshEnumValue chosenSwitchMeshEnumValue)
                {
                        _chosenSwitchMeshEnumValue = chosenSwitchMeshEnumValue;
                        return true;
                }

                public bool SetSwitchMaterial(Material switchMaterial)
                {
                        _switchMaterial = switchMaterial;
                        return true;
                }
                public bool SetLabelMeshEnumValue(LabelMeshEnumValue chosenLabelMeshEnumValue)
                {
                        _chosenLabelMeshEnumValue = chosenLabelMeshEnumValue;
                        return true;
                }

                public bool SetLabelText(string labelText)
                {
                        _labelText = labelText;
                        return true;
                }
                
                public bool SetIsSwitchPressAnimationInUse(bool isSwitchPressAnimationInUse)
                {
                        _isSwitchPressAnimationInUse = isSwitchPressAnimationInUse;
                        return true;
                }

                public bool SetSwitchPressAnimation(SwitchPressAnimation switchPressAnimation)
                {
                        _switchPressAnimation = switchPressAnimation;
                        return true;
                }
                
                public bool SetIsSwitchAnimatorInUse(bool isSwitchAnimatorInUse)
                {
                        _isSwitchAnimatorInUse = isSwitchAnimatorInUse;
                        return true;
                }

                public bool SetSwitchAnimator(Animator switchAnimator)
                {
                        _switchAnimator = switchAnimator;
                        return true;
                }

                #endregion


                public void UpdateRecipe()
                {

                }

                public void ChangeFrame(SwitchBase switchBase)
                {
                        //GameObject gameObject = switchBase.GetComponentInChildren<SwitchFramePrefab>().gameObject;
                }

                public void SetFrameMesh(GameObject gameObject)
                {
                        throw new NotImplementedException();
                }

                public void SetBackgroundMesh(GameObject gameObject)
                {
                        throw new NotImplementedException();
                }

                public void SetCoverMesh(GameObject gameObject)
                {
                        throw new NotImplementedException();
                }

                public void SetImageMesh(GameObject gameObject)
                {
                        throw new NotImplementedException();
                }

                public void SetSwitchMesh(GameObject gameObject)
                {
                        throw new NotImplementedException();
                }

                public void SetLabelMesh(GameObject gameObject)
                {
                        throw new NotImplementedException();
                }
        }
}
