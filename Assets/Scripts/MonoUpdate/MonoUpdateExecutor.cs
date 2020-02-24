using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoUpdate
{
    public class MonoUpdateExecutor : MonoBehaviour
    {
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
