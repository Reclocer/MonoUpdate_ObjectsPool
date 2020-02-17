using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoUpdate
{
    public class MonoUpdateExecutor : MonoBehaviour
    {
        //Initialization
        private void Awake()
        {
            for(int i = 0; i < MonoUpdateClass.ListAwakes.Count; i++)
            {
                MonoUpdateClass.ListAwakes[i].MonoAwakeFunc();
            }
        }

        private void Start()
        {
            for (int i = 0; i < MonoUpdateClass.ListStarts.Count; i++)
            {
                MonoUpdateClass.ListStarts[i].MonoStartFunc();
            }
        }

        //Physics
        private void FixedUpdate()
        {
            for (int i = 0; i < MonoUpdateClass.ListFixedUpdates.Count; i++)
            {
                MonoUpdateClass.ListFixedUpdates[i].MonoFixedUpdateFunc();
            }
        }

        //Logic
        private void Update()
        {
            for (int i = 0; i < MonoUpdateClass.ListUpdates.Count; i++)
            {
                MonoUpdateClass.ListUpdates[i].MonoUpdateFunc();
            }
        }

    }
}
