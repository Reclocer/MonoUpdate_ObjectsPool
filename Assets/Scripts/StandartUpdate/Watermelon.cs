using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace StandartUpdate
{
    [RequireComponent(typeof(Rigidbody))]
    public class Watermelon : MonoBehaviour, IStickable
    {
        [SerializeField] private int _maxStickObjects = 3;
        public int MaxStickObjects => _maxStickObjects;
        //private int _stickObjectsNow = 0;

        private Rigidbody _rigidbody;
        public Rigidbody SticableBody => _rigidbody;       

        private List<Rigidbody> _listObjects = new List<Rigidbody>();

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            //_stickObjectsNow = _maxStickObjects; //!!!!!!

        }

        private void Update()
        {
            //if (_listObjects.Count > _stickObjectsNow)
            //{
            //    transform.DetachChildren();

            //    foreach (Rigidbody rigidbody in _listObjects)
            //    {
            //        rigidbody.useGravity = true;
            //        _listObjects.Remove(rigidbody);
            //    }

            //    _stickObjectsNow += _maxStickObjects;
            //}
        }

        /// <summary>
        /// Rigidbody object stick to watermelon 
        /// </summary>
        /// <param name="rigidbody"></param>
        public void StickObject(Rigidbody rigidbody)
        {
            _listObjects.Add(rigidbody);
            rigidbody.gameObject.transform.SetParent(transform);            
        }

        /// <summary>
        /// Rigidbody object unstick 
        /// </summary>
        /// <param name="rigidbody"></param>
        public void UnStick(Rigidbody rigidbody)
        {
            _listObjects.Remove(rigidbody);
            rigidbody.gameObject.transform.parent = null;
        }
    }
}
