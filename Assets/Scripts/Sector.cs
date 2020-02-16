using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandartUpdate
{
    public class Sector : MonoBehaviour, ICreateObjects
    {
        [SerializeField] private Level _level;        

        private List<Level> _levelList = new List<Level>();

        [SerializeField] private float _offSetPosition;
        public float OffsetPosition => _offSetPosition;

        private int _levelCount = 0;

        // Start is called before the first frame update
        void Start()
        {
            _levelList.Add(_level);
            _level.OnLevelFirstStepDone += (level) => { CreateObjectWithOffset(); };
            _level.OnLevelFirstStepDone += LevelEventComeOff;
            CreateObjectWithOffset();
        }

        public void CreateObjectWithOffset()
        {
            Vector3 newLevelPosition = new Vector3(0, transform.position.y + _offSetPosition, 0);
            Level newLevel = GameObject.Instantiate(_level, newLevelPosition, Quaternion.identity, transform);
            _levelList.Add(newLevel);

            newLevel.OnLevelFirstStepDone += (level) => { CreateObjectWithOffset(); };
            newLevel.OnLevelFirstStepDone += LevelEventComeOff;

            _levelCount++;
            _offSetPosition += 4;
        }

        private void LevelEventComeOff(Level level)
        {
            level.OnLevelFirstStepDone -= (level1) => { CreateObjectWithOffset(); };
            level.OnLevelFirstStepDone -= LevelEventComeOff;
        }
    }
}