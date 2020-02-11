using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace StandartUpdate
{
    public class Watermelon : MonoBehaviour, IStickable
    {
        [SerializeField] private int _maxStickObjects = 10;
        public int MaxStickObjects => _maxStickObjects;

        private List<Rigidbody> _listObjects = new List<Rigidbody>();

        private void Update()
        {
            if (_listObjects.Count > _maxStickObjects)
            {
                transform.DetachChildren();

                foreach (Rigidbody rigidbody in _listObjects)
                {
                    rigidbody.useGravity = true;
                    _listObjects.Remove(rigidbody);
                }
            }
        }

        public void StickObject(Rigidbody rigidbody)
        {
            _listObjects.Add(rigidbody);
            rigidbody.gameObject.transform.SetParent(transform);
        }
    }
}
