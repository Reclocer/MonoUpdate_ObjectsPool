using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoUpdate
{
    public class MonoUpdateClass : MonoBehaviour
    {
        //Initialization
        public static List<MonoUpdateClass> ListAwakes = new List<MonoUpdateClass>();
        public static List<MonoUpdateClass> ListStarts = new List<MonoUpdateClass>();

        //Physics
        public static List<MonoUpdateClass> ListFixedUpdates = new List<MonoUpdateClass>();        

        //Logic
        public static List<MonoUpdateClass> ListUpdates = new List<MonoUpdateClass>();
        

        //Initialization
        public virtual void MonoAwakeFunc()
        {

        }

        private void OnEnable()
        {
            ListAwakes.Add(this);
            ListStarts.Add(this);
            ListFixedUpdates.Add(this);
            ListUpdates.Add(this);
        }

        public virtual void MonoStartFunc()
        {

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
            ListAwakes.Remove(this);
            ListStarts.Remove(this);
            ListFixedUpdates.Remove(this);
            ListUpdates.Remove(this);
        }
    }
}
