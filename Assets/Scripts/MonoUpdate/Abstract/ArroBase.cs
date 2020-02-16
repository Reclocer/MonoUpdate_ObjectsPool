using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoUpdate
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class ArrowBase : MonoUpdateClass
    {
        [SerializeField] protected float _distanceToStick = 1;
        protected IStickable _lastSticable;
        protected FixedJoint _fixedJoint;

        protected Rigidbody _rigidbody;
        [HideInInspector]
        public Rigidbody Rigidbody
        {
            get { return _rigidbody; }
            set { _rigidbody = value; }
        }

        protected virtual void MonoAwakeFunc()
        {
            _rigidbody = GetComponent<Rigidbody>();
            Transform parentTransform = GetComponentInParent<Transform>();
        }
    }
}