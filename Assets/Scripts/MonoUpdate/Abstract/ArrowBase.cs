using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoUpdate
{
    [RequireComponent(typeof(Rigidbody))]
    public class ArrowBase : MonoUpdateClass
    {
        [SerializeField] protected float _distanceToStick = 1;
        protected IStickable _lastSticable;
        protected FixedJoint _fixedJoint;
        protected Rigidbody _rigidbody;
        

        public override void MonoAwakeFunc()
        {
            base.MonoAwakeFunc();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public virtual Rigidbody GetRigidbody()
        {
            return _rigidbody;
        }

        public virtual void SetRigidbody(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }
    }
}