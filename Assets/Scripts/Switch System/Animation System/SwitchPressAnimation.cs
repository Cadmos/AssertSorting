using Debug_System;
using Extensions;
using UnityEngine;

namespace Switch_System.Animation_System
{
    public class SwitchPressAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToBeAnimated;
        [SerializeField] private float _amountMoved;
        [SerializeField] private float _animationDuration;
        [SerializeField] private Vector3 _directionInLocalSpace;
        private bool _isPressed;
        [SerializeField]private Vector3 _originalPosition;

        private Coroutine _fadeRoutine;
        private Coroutine _release;

        public void PressedAnimation()
        {
            this.EnsureCoroutineStopped(ref _fadeRoutine);
            Vector3 startPosition = GetObjectToBeAnimated().transform.position;
            Vector3 endPosition = startPosition + GetDirectionInLocalSpace() * _amountMoved;
            Debug.Log("press anim");
            _fadeRoutine = this.CreateAnimationRoutine(GetAnimationDuration(),
                delegate(float progress)
                {
                    GetObjectToBeAnimated().transform.position = Vector3.MoveTowards(startPosition, endPosition, progress);
                }, delegate { _fadeRoutine = null; });
        }

        public void HeldAnimation()
        {
        }
    
        public void ReleasedAnimation()
        {
            this.EnsureCoroutineStopped(ref _fadeRoutine);
            Vector3 startPosition = GetObjectToBeAnimated().transform.position;
            Vector3 endPosition = GetOriginalPosition();
            Debug.Log("release anim");
            _fadeRoutine = this.CreateAnimationRoutine(GetAnimationDuration(),
                delegate(float progress)
                {
                    GetObjectToBeAnimated().transform.position = Vector3.MoveTowards(startPosition, endPosition, progress);
                }, delegate { _fadeRoutine = null; });
        }
    

        #region Get

        public GameObject GetObjectToBeAnimated()
        {
            return _objectToBeAnimated;
        }

        public float GetAmountMoved()
        {
            return _amountMoved;
        }

        public float GetAnimationDuration()
        {
            return _animationDuration;
        }

        public Vector3 GetDirectionInLocalSpace()
        {
            return _directionInLocalSpace;
        }

        public bool GetIsPressed()
        {
            return _isPressed;
        }

        public Vector3 GetOriginalPosition()
        {
            return _originalPosition;
        }

        #endregion

        #region Set

        public bool SetObjectToBeAnimated(GameObject objectToBeAnimated)
        {
            _objectToBeAnimated = objectToBeAnimated;
            return true;
        }

        public bool SetAmountMoved(float amountMoved)
        {
            _amountMoved = amountMoved;
            return true;
        }

        public bool SetAnimationDuration(float animationDuration)
        {
            _animationDuration = animationDuration;
            return true;
        }

        public bool SetDirectionInLocalSpace(Vector3 directionInLocalSpace)
        {
            _directionInLocalSpace = directionInLocalSpace;
            return true;
        }

        public bool SetIsPressed(bool isPressed)
        {
            _isPressed = isPressed;
            return true;
        }

        public bool SetOriginalPosition(Vector3 originalPosition)
        {
            _originalPosition = originalPosition;
            return true;
        }

        #endregion

        private void Awake()
        {
            SetOriginalPosition(GetObjectToBeAnimated().transform.position);
        }
    }
}