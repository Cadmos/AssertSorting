using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Switch_System
{
    [Serializable]
    public class ObjectBuilderParts
    {
        private List<ObjectBuilderPart> _objectBuilderParts;

        #region Get

        public List<ObjectBuilderPart> GetObjectBuilderParts()
        {
            return _objectBuilderParts;
        }

        #endregion

        #region Set

        public bool SetObjectBuilderParts(List<ObjectBuilderPart> objectBuilderParts)
        {
            _objectBuilderParts = objectBuilderParts;
            return true;
        }

        #endregion
        
        public void InitializeObjectBuilderParts()
        {
            SetObjectBuilderParts(new List<ObjectBuilderPart>());
        }
        
        public void AddObjectBuilderPart(ObjectBuilderPart objectBuilderPart)
        {
            GetObjectBuilderParts().Add(objectBuilderPart);
        }
    
        

        
        
        

    }
}