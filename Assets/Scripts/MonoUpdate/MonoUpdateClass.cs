using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoUpdate
{
    public class MonoUpdateClass : MonoBehaviour
    {
        //Physics
        public static List<MonoUpdateClass> ListFixedUpdates = new List<MonoUpdateClass>();        

        //Logic
        public static List<MonoUpdateClass> ListUpdates = new List<MonoUpdateClass>();
        
              
        //Initialization
        private void OnEnable()
        {            
            ListFixedUpdates.Add(this);
            ListUpdates.Add(this);
        }        

        //Physics
        public virtual void MonoFixedUpdateFunc()
        {

        }
       

        //Logic
        public virtual void MonoUpdateFunc()
        {
            
        }

        private void OnDisable()
        {            
            ListFixedUpdates.Remove(this);
            ListUpdates.Remove(this);
        }
    }
}
