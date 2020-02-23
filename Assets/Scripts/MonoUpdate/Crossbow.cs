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
        //[SerializeField] private int _maxCountArrowsInPool = 2;
        private int _maxCountArrowsInPool = 9;//!!!!!!!!!!!!!!!!!!!!!!!!
        [SerializeField] private const float _shotIntervalTime = 1f;
        private float _time;
        private Queue<ArrowBase> _queueArrowBases;

        //public override void MonoStartFunc()
        //{
        //    InvokeRepeating("CreateArrow", 0, 2);
        //}

         void Awake()
        {
            _queueArrowBases = new Queue<ArrowBase>(_maxCountArrowsInPool);
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
                Debug.Log(_queueArrowBases.Count);
                ArrowBase arrow = _queueArrowBases.Peek();
                _queueArrowBases.Dequeue();
                ShotArrow(arrow);
                _queueArrowBases.Enqueue(arrow);
            }
            else
            {
                _time -= Time.deltaTime;
            }
        }

        private ArrowBase CreateArrow()
        {
            ArrowBase arrow = _arrowFactory.CreateArrow<Arrow>();
            arrow.gameObject.SetActive(false);
            return arrow;           
        }

        private void ShotArrow(ArrowBase arrow)
        {
            arrow.gameObject.SetActive(true);

            Rigidbody arrowRigidbody = arrow.GetRigidbody();
            
            arrowRigidbody.angularVelocity = Vector3.zero;
            arrowRigidbody.velocity = Vector3.zero;
            arrowRigidbody.inertiaTensor = new Vector3(1,1,1);

            arrow.transform.SetParent(this.transform);
            arrow.transform.rotation = transform.rotation;
            
            arrow.transform.position = _arrowStartPosition.position;

            arrowRigidbody.AddRelativeForce(1000, 0, 0);
            //arrow.SetRigidbody(arrowRigidbody);
        }
    }
}
