using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandartUpdate
{        
    public class Arrow : ArrowBase 
    {
        protected override void Awake()
        {
            base.Awake();            
        }

        private void Update()
        {            
            CheckStickableObject();            
        }

        private void CheckStickableObject()
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.right, Color.red);

            if(Physics.Raycast(transform.position, transform.right, out hit, _distanceToStick))
            {
                IStickable stickable = hit.collider.GetComponent<IStickable>();

                if(stickable != null && stickable != _lastSticable)                
                {    
                    // Rigidbody functions disable                      
                    _rigidbody.useGravity = false;
                    _rigidbody.angularVelocity = Vector3.zero;
                    _rigidbody.velocity = Vector3.zero;

                    _fixedJoint = gameObject.AddComponent<FixedJoint>();
                    _fixedJoint.connectedBody = stickable.SticableBody; 

                    stickable.StickObject(_rigidbody);
                    _lastSticable = stickable;
                }
            }
            else if (_lastSticable != null)
            {
                _rigidbody.useGravity = true;
                _lastSticable.UnStick(_rigidbody);
                Destroy(_fixedJoint);             //!!!!!!                
            }
        }       
    }
}
