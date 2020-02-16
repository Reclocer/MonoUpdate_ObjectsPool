using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandartUpdate
{
    public class Sector : MonoBehaviour, ICreateObjects
    {
        [SerializeField] private Level _level;
        //private List<Level> _levelList = new List<Level>();

        [SerializeField] private float _offSetPosition;
        public float OffsetPosition => _offSetPosition;
        private float _newLevelPosition;

        private int _levelCount = 0;

        // Start is called before the first frame update
        private void Start()
        {
            Create();            
        }

        /// <summary>
        /// Create level prefab. Increment _levelCount and _newLevelPosition. 
        /// </summary>
        public void Create()
        {
            Vector3 newLevelPosition = new Vector3(0, transform.position.y + _newLevelPosition, 0);
            Level newLevel = GameObject.Instantiate(_level, newLevelPosition, Quaternion.identity, transform);
            //_levelList.Add(newLevel);

            newLevel.OnLevelFirstStepDone += (level) => { Create(); };
            newLevel.OnLevelFirstStepDone += LevelEventComeOff;

            _levelCount++;
            _newLevelPosition += _offSetPosition;
        }

        private void LevelEventComeOff(Level level)
        {
            level.OnLevelFirstStepDone -= (level1) => { Create(); };
            level.OnLevelFirstStepDone -= LevelEventComeOff;
        }
    }
}