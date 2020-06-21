using System;
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

        public StickStatus StickStatus { get; set;} = StickStatus.None;

        public event Action<ArrowBase> OnUnStick = (arrow) => { };

        protected virtual void Awake()
        {            
            _rigidbody = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Get Rigidbody
        /// </summary>
        /// <returns></returns>
        public virtual Rigidbody GetRigidbody()
        {
            return _rigidbody;
        }

        /// <summary>
        /// Set Rigidbody
        /// </summary>
        /// <param name="rigidbody"></param>
        public virtual void SetRigidbody(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public virtual void CheckStickableObject()
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.right, Color.red);

            if (Physics.Raycast(transform.position, transform.right, out hit, _distanceToStick))
            {
                IStickable stickable = hit.collider.GetComponent<IStickable>();

                if (stickable != null && stickable != _lastSticable)
                {
                    // Rigidbody functions disable                      
                    _rigidbody.useGravity = false;
                    _rigidbody.angularVelocity = Vector3.zero;
                    _rigidbody.velocity = Vector3.zero;

                    _fixedJoint = gameObject.AddComponent<FixedJoint>();
                    _fixedJoint.connectedBody = stickable.SticableBody;

                    StickStatus = StickStatus.Stick;
                    
                    stickable.StickObject(_rigidbody);
                    _lastSticable = stickable;
                }
            }
            else if (_lastSticable != null)
            {
                _rigidbody.useGravity = true;
                _lastSticable.UnStick(_rigidbody);
                StickStatus = StickStatus.Unstick;
                OnUnStick(this);
                Destroy(_fixedJoint);             //!!!!!!      
                _lastSticable = null;
            }
        }
    }
}