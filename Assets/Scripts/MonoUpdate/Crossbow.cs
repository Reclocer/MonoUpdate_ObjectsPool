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

        private void MonoStartFunc()
        {
            InvokeRepeating("CreateArrow", 0, 2);
        }

        private void CreateArrow()
        {
            ArrowBase arrow = _arrowFactory.CreateArrow<Arrow>();
            arrow.transform.position = _arrowStartPosition.position;
            ShotArrow(arrow);
        }

        private void ShotArrow(ArrowBase arrow)
        {
            arrow.Rigidbody.AddRelativeForce(1000, 0, 0);
        }
    }
}
