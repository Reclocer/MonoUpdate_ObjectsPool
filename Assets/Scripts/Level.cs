using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandartUpdate
{
    public class Level : MonoBehaviour, ICreateObjects
    {
        [SerializeField] private Transform _cell;        

        [SerializeField] private float _cellOffSetPositionZ;
        public float OffsetPosition => _cellOffSetPositionZ;
        private float _newCellPosition;

        private int _objectsCount = 0;        

        public event Action<Level> OnLevelFirstStepDone = (level) => { };

        private void Start()
        {
            Create();
            _objectsCount++;
            _newCellPosition += _cellOffSetPositionZ;
        }

        private void Update()
        {
            //Debug.Log(Time.deltaTime);            

            if (_objectsCount < 20)
            {                               
                Create();
                _objectsCount++;
                _newCellPosition += _cellOffSetPositionZ;                

                if (_objectsCount == 10 && Time.deltaTime < 0.02f)                
                {
                    OnLevelFirstStepDone(this);
                }
            }
        }

        /// <summary>
        /// Create cell prefab
        /// </summary>
        public void Create()
        {
            Vector3 newCellPosition = new Vector3(transform.position.x, 
                                                  transform.position.y, 
                                                  transform.position.z + _newCellPosition);
            GameObject.Instantiate(_cell, newCellPosition, Quaternion.identity, transform);            
        }
    }
}
