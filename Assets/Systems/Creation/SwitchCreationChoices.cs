using System;
using Switch_System.Creation_System.ScriptableObjects.Enums;
using UnityEngine;

namespace Switch_System.Creation_System
{
    public class SwitchCreationChoices : MonoBehaviour
    {
        [SerializeField] private SwitchRecipe _switchRecipe;
        private FrameMeshEnumValue _frameMeshEnumValue;
        private BackgroundMeshEnumValue _backgroundMeshEnumValue;
        private CoverMeshEnumValue _coverMeshEnumValue;
        private ImageMeshEnumValue _imageMeshEnumValue;
        private SwitchMeshEnumValue _switchMeshEnumValue;
        private LabelMeshEnumValue _labelMeshEnumValue;

        #region Constructors

        #endregion

        #region Get

        public FrameMeshEnumValue GetFrameMeshEnumValue()
        {
            return _frameMeshEnumValue;
        }

        public BackgroundMeshEnumValue GetBackGroundMeshEnumValue()
        {
            return _backgroundMeshEnumValue;
        }

        public CoverMeshEnumValue GetCoverMeshEnumValue()
        {
            return _coverMeshEnumValue;
        }

        public ImageMeshEnumValue GetImageMeshEnumValue()
        {
            return _imageMeshEnumValue;
        }

        public SwitchMeshEnumValue GetSwitchMeshEnumValue()
        {
            return _switchMeshEnumValue;
        }

        public LabelMeshEnumValue GetLabelMeshEnumValue()
        {
            return _labelMeshEnumValue;
        }

        #endregion

        #region Set

        public bool SetFrameMeshEnumValue(FrameMeshEnumValue frameMeshEnumValue)
        {
            _frameMeshEnumValue = frameMeshEnumValue;
            ChangeFrameMesh();
            return true;
        }

        public bool SetBackgroundMeshEnumValue(BackgroundMeshEnumValue backgroundMeshEnumValue)
        {
            _backgroundMeshEnumValue = backgroundMeshEnumValue;
            ChangeBackgroundMesh();
            return true;
        }

        public bool SetCoverMeshEnumValue(CoverMeshEnumValue coverMeshEnumValue)
        {
            _coverMeshEnumValue = coverMeshEnumValue;
            ChangeCoverMesh();
            return true;
        }



        public bool SetImageMeshEnumValue(ImageMeshEnumValue imageMeshEnumValue)
        {
            _imageMeshEnumValue = imageMeshEnumValue;
            ChangeImageMesh();
            return true;
        }


        public bool SetSwitchMeshEnumValue(SwitchMeshEnumValue switchMeshEnumValue)
        {
            _switchMeshEnumValue = switchMeshEnumValue;
            ChangeSwitchMesh();
            return true;
        }


        public bool SetLabelMeshEnumValue(LabelMeshEnumValue labelMeshEnumValue)
        {
            _labelMeshEnumValue = labelMeshEnumValue;
            ChangeLabelMesh();
            return true;
        }


        #endregion


        private void Start()
        {
            throw new NotImplementedException();

            //TODO if stuff is null then create stuff
        }

        private void OnValidate()
        {

        }

        private void ChangeFrameMesh()
        {
            _switchRecipe.SetFrameMesh(gameObject);
            
        }

        private void ChangeBackgroundMesh()
        {
            _switchRecipe.SetBackgroundMesh(gameObject);
        }

        private void ChangeCoverMesh()
        {
            _switchRecipe.SetCoverMesh(gameObject);
        }

        private void ChangeImageMesh()
        {
            _switchRecipe.SetImageMesh(gameObject);
        }

        private void ChangeSwitchMesh()
        {
            _switchRecipe.SetSwitchMesh(gameObject);
        }

        private void ChangeLabelMesh()
        {
            _switchRecipe.SetLabelMesh(gameObject);
        }
    }
}
