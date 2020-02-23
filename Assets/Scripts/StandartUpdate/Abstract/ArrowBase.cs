using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandartUpdate
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class ArrowBase : MonoBehaviour
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

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();            
        }
    }
}
