using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Switch_System
{
    public class SwitchGroup : MonoBehaviour
    {
        
        [SerializeField]private List<SwitchBase> _switches;
        [SerializeField]private SwitchBase _activeSwitch;

        private void Awake()
        {
            InitializeObjects();
        }

        private void InitializeObjects()
        {
            _switches = GetComponentsInChildren<SwitchBase>().ToList();
        }

        private void OnValidate()
        {
            InitializeObjects();
        }

        public void UpdateSwitchGroup(SwitchBase activatedSwitch)
        {
            if (activatedSwitch == _activeSwitch)
                return;
            
            _switches.ForEach(s =>
            {
                if (s = activatedSwitch)
                    return;
                s.UpdateSwitch(SwitchState.On,true);
            });
            
            
        }
    }
}