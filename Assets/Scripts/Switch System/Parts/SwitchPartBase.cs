using UnityEngine;

namespace Switch_System.Parts
{
    public abstract class SwitchPartBase : MonoBehaviour
    {
        [SerializeField] private SwitchBase _parent;

        private void Awake()
        {
            _parent = GetComponentInParent<SwitchBase>();
        }

        private void OnValidate()
        {
            _parent = GetComponentInParent<SwitchBase>();
        }

        private void OnEnable()
        {
            _parent = GetComponentInParent<SwitchBase>();
        }
    }
}
