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
        public void MonoAwakeFunc()
        {

        }

        public void MonoStartFunc()
        {

        }

        //Physics
        public void MonoFixedUpdateFunc()
        {

        }
       

        //Logic
        public void MonoUpdateFunc()
        {

        }
    }
}
