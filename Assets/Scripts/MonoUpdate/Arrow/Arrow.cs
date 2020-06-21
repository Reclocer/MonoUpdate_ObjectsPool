using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoUpdate
{
    public class Arrow : ArrowBase
    {         
        protected override void Awake()
        {
            base.Awake();            
        }

        public override void MonoUpdateFunc()
        {
            CheckStickableObject();
        }

        /// <summary>
        /// Get Rigidbody
        /// </summary>
        /// <returns></returns>
        public override Rigidbody GetRigidbody()
        {
            return base.GetRigidbody();
        }

        /// <summary>
        /// Set Rigidbody
        /// </summary>
        /// <param name="rigidbody"></param>
        public override void SetRigidbody(Rigidbody rigidbody)
        {
            base.SetRigidbody(rigidbody);
        }

        public override void CheckStickableObject()
        {
            base.CheckStickableObject();
        }
    }
}
