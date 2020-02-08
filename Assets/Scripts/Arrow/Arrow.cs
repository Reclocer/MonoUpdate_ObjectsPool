using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandartUpdate
{
    [RequireComponent(typeof(Rigidbody))]
    public class Arrow : ArrowBase 
    {
        [SerializeField] private float _distanceToStick = 1;// in base
        private Rigidbody _rigidbody;                       // in base

        private void Start()// in base
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            CheckStickableObject();
        }

        private void CheckStickableObject()
        {
            RaycastHit hit;

            if(Physics.Raycast(transform.position, transform.forward, out hit, _distanceToStick))
            {
                IStickable stickable = hit.collider.GetComponent<IStickable>();

                if(stickable != null)
                {
                    stickable.StickObject(_rigidbody);
                    _rigidbody.useGravity = false;
                }
            }
        }
    }
}
