using System.IO;
using Switch_System.Animation_System;
using Switch_System.Creation_System.ScriptableObjects.Enums;
using Switch_System.Creation_System.ScriptableObjects.Enums.Dictionaries;
using UnityEditor;
using UnityEngine;

namespace Switch_System
{
        public class SwitchBuilder : MonoBehaviour
        {

                [Header("ToggleGroup")]
                [Tooltip("Will find parent object with SwitchGroup script. If SwitchBase belongs to a SwitchGroup it becomes a Toggle type")]
                [SerializeField] private SwitchGroup _switchGroup;
                
                [Header("Recipe")]
                [Tooltip("Insert a ScriptableObject type of SwitchRecipe. Switch will be built based on the recipe")]
                [SerializeField] private SwitchRecipe _switchRecipe;

                [Header("Functionality")] 
                [SerializeField] private SwitchType _switchType;
                [SerializeField] private SwitchToggle _switchToggle;
                [SerializeField] private SwitchControlType _switchControlType;
                [SerializeField] private SwitchSignalType _switchSignalType;
                [SerializeField] private SwitchState _switchState;
                
                [Header("Indicators")]
                [SerializeField] private SwitchLight _switchLight;

                [SerializeField] private bool _isActive;
                [SerializeField] private bool _isAbleToTurnItselfOff;
                
                [Header("Light")]
                [Tooltip("Will find child object with EmissiveObject script")]
                [SerializeField] private EmissiveObject _emissiveObject;
                [SerializeField] private Color _colorActive;
                [SerializeField] private Color _colorInactive;


                [SerializeField] private string _prefabName;
                [Header("Graphics")] 
                [SerializeField] private FrameMeshEnumValue _chosenFrameMeshEnumValue;
                [SerializeField] private Material _frameMaterial;

                [SerializeField] private BackgroundMeshDictionary _backgroundMeshDictionary;
                [SerializeField] private BackgroundMeshEnumValue _chosenBackgroundMeshEnumValue;
                [SerializeField] private GameObject _backgroundGameObject;
                [SerializeField] private MeshRenderer _backgroundMeshRenderer;
                [SerializeField] private MeshFilter _backgroundMeshFilter;
                [SerializeField] private Mesh _backgroundMesh;
                [SerializeField] private Material _backgroundMaterial;
                [SerializeField] private Color _backgroundMaterialColor;
                [SerializeField] private int _ignoreRaycastLayer = LayerMask.NameToLayer("Ignore Raycast"); //TODO sort out elsewhere
                
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
                
                #region Constructors
                private void Awake()
                {
                        //InitializeSwitchObjects();
                }

                private void Start()
                {
                        //InitializeSwitchVariables();
                }

                private void OnValidate()
                {
                        //InitializeSwitchObjects();
                        //InitializeSwitchVariables();

                }

                private void CreateBackground()
                {
                        if (_backgroundGameObject == null)
                        {
                                _backgroundGameObject = new GameObject();
                                _backgroundGameObject.transform.parent = transform;
                                _backgroundGameObject.name = "Background";
                                _backgroundGameObject.AddComponent<MeshRenderer>();
                                _backgroundGameObject.AddComponent<MeshFilter>();
                                _backgroundMeshRenderer = GetComponent<MeshRenderer>();
                                _backgroundMeshFilter = GetComponent<MeshFilter>();
                                _backgroundMeshFilter.sharedMesh = _backgroundMesh;
                                
                                _backgroundMaterial.SetColor("_BaseColor", _backgroundMaterialColor);
                                _backgroundMeshRenderer.sharedMaterial = _backgroundMaterial;

                                _backgroundGameObject.isStatic = true;
                                _backgroundGameObject.layer = _ignoreRaycastLayer;
                                
                                
                                //TODO collect all involved game objects into an array
                                if (!Directory.Exists("Assets/Prefabs"))
                                        AssetDatabase.CreateFolder("Assets", "Prefabs");
                                AssetDatabase.CreateFolder("Assets/Prefabs", "Buttons");

                                string localPath = "Assets/Prefabs/Buttons/" + gameObject.name + ".prefab";

                                localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

                                PrefabUtility.SaveAsPrefabAsset(_backgroundGameObject, localPath, out bool prefabSuccess );

                                if (prefabSuccess)
                                {
                                        Debug.Log("Prefab was saved successfully");
                                }
                                else
                                {
                                        Debug.Log("Prefab failed to save");
                                }
                        }
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

                private void InitializeSwitchRecipeVariables()
                {
                        _backgroundMesh = _backgroundMeshDictionary._meshEnumLinks.Find(m => m.type == _chosenBackgroundMeshEnumValue).mesh;
                }
                #endregion

                #region Get

                
                public SwitchGroup GetSwitchGroup()
                {
                        return _switchGroup;
                }
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
                public SwitchLight GetSwitchLight()
                {
                        return _switchLight;
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
                
                public bool SetSwitchGroup(SwitchGroup switchGroup)
                {
                        _switchGroup = switchGroup;
                        return true;
                }

                public bool SetSwitchRecipe(SwitchRecipe switchRecipe)
                {
                        _switchRecipe = switchRecipe;
                        InitializeSwitchRecipeVariables();
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
                
                public bool SetSwitchLight(SwitchLight switchLight)
                {
                        _switchLight = switchLight;
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
