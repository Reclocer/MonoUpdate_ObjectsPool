using Corebin.Core.ObjectsPool.ObjectsQueue;
using UnityEngine;

namespace MonoUpdate
{
    [RequireComponent(typeof(ArrowFactory))]
    public class Crossbow : MonoUpdateClass
    {
        [SerializeField] private ArrowFactory _arrowFactory;
        [SerializeField] private Transform _arrowStartPosition;
        [SerializeField] private const float _shotIntervalTime = 1f;
        private float _time;

        private ObjectsPoolQueue<ArrowBase> _objectsPoolQueue;

        private void Awake()
        {
            _objectsPoolQueue = new ObjectsPoolQueue<ArrowBase>(16);
            ArrowBase arrow;

            for (int i = 0; i < 16; i++)
            {
                arrow = CreateArrow();
                _objectsPoolQueue.Enqueue(arrow);
            }
        }

        public override void MonoUpdateFunc()
        {
            if (_time <= 0)
            {
                _time = _shotIntervalTime;
                ArrowBase arrow = _objectsPoolQueue.Dequeue();

                if (arrow == null)
                {
                    arrow = CreateArrow();
                }

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
            _objectsPoolQueue.Enqueue(arrow);
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
