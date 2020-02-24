using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoUpdate
{
    [RequireComponent(typeof(ArrowFactory))]
    public class Crossbow : MonoUpdateClass
    {
        [SerializeField] private ArrowFactory _arrowFactory;
        [SerializeField] private Transform _arrowStartPosition;
        [SerializeField] private int _maxCountArrowsInPool = 20;        
        [SerializeField] private const float _shotIntervalTime = 1f;
        private float _time;        
        private Queue<ArrowBase> _queueArrowBases;
        private Queue<ArrowBase> _queueUnstickedArrowBases;

        private void Awake()
        {
            _queueArrowBases          = new Queue<ArrowBase>(_maxCountArrowsInPool);
            _queueUnstickedArrowBases = new Queue<ArrowBase>(_maxCountArrowsInPool);
            ArrowBase arrow;

            for (int i = 0; i < _maxCountArrowsInPool; i++)
            {                
                arrow = CreateArrow();
                _queueArrowBases.Enqueue(arrow);
            }            
        }

        public override void MonoUpdateFunc()
        {
            if(_time <= 0)
            {
                _time = _shotIntervalTime;
                ArrowBase arrow = ChoiceNextArrow();
                ShotArrow(arrow);               
            }
            else
            {
                _time -= Time.deltaTime;
            }
        }

        private ArrowBase CreateArrow()
        {
            ArrowBase arrow = _arrowFactory.CreateArrow<Arrow>();
            arrow.OnUnStick += AddArrowToQueueUnstick;
            arrow.gameObject.SetActive(false);
            return arrow;           
        }

        private void AddArrowToQueueUnstick(ArrowBase arrow)
        {
            _queueUnstickedArrowBases.Enqueue(arrow);
        }

        private ArrowBase ChoiceNextArrow()
        {
            ArrowBase arrow;

            if (_queueUnstickedArrowBases.Count != 0)
            {                
                arrow = _queueUnstickedArrowBases.Peek();
                _queueUnstickedArrowBases.Dequeue();
                return arrow;
            }
            else
            {
                arrow = _queueArrowBases.Peek();
                _queueArrowBases.Dequeue();
                _queueArrowBases.Enqueue(arrow);
                return arrow;
            }
        }

        private void ShotArrow(ArrowBase arrow)
        {
            arrow.gameObject.SetActive(true);                        
            Rigidbody arrowRigidbody = arrow.GetRigidbody();

            arrow.transform.SetParent(transform);
            arrow.transform.rotation = transform.rotation;
            arrow.transform.position = _arrowStartPosition.position;

            arrowRigidbody.angularVelocity = Vector3.zero;
            arrowRigidbody.velocity        = Vector3.zero;

            arrow.StickStatus = StickStatus.None;

            arrowRigidbody.AddRelativeForce(1000, 0, 0);
            arrow.SetRigidbody(arrowRigidbody);
        }
    }
}
