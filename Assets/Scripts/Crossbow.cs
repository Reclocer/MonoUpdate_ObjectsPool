using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandartUpdate
{
    [RequireComponent(typeof(ArrowFactory))]
    public class Crossbow : MonoBehaviour
    {
        [SerializeField] private ArrowFactory _arrowFactory;
        
        void Start()
        {            
            InvokeRepeating("CreateArrow", 1,1);                        
        }

        private void CreateArrow()
        {
            ArrowBase arrow = _arrowFactory.CreateArrow<Arrow>();
            ShotArrow(arrow);
        }

        private void ShotArrow(ArrowBase arrow)
        {            
            arrow.Rigidbody.AddRelativeForce(1000, 0, 0);
        }        
    }
}
