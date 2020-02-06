using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandartUpdate
{
    public class Level : MonoBehaviour, ICreateObjects
    {
        [SerializeField] private Transform _cell;
        //[SerializeField] private Vector3 _cellOffSetPosition;

        [SerializeField] private float _cellOffSetPositionZ;
        public float OffsetPosition => _cellOffSetPositionZ;

        private int _objectsCount = 0;        

        public event Action<Level> OnLevelFirstStepDone = (level) => { };

        private void Update()
        {
            //Debug.Log(Time.deltaTime);
            

            if (_objectsCount < 20)
            {
                Debug.Log("количество объектов " + _objectsCount);
                Debug.Log(_cellOffSetPositionZ);
                CreateObjectWithOffset();

                if (_objectsCount == 10)
                {
                    OnLevelFirstStepDone(this);
                }
            }

        }

        public void CreateObjectWithOffset()
        {
            Vector3 newCellPosition = new Vector3(transform.position.x, 
                                                  transform.position.y, 
                                                  transform.position.z + _cellOffSetPositionZ);
            GameObject.Instantiate(_cell, newCellPosition, Quaternion.identity, transform);
            _objectsCount++;
            _cellOffSetPositionZ += 2;
        }
    }
}
