using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandartUpdate
{
    public class ArrowFactory : MonoBehaviour
    {
        [SerializeField] private List<ArrowBase> _listArows;

        public ArrowBase CreateArrow<T>() where T : ArrowBase
        {
            foreach (ArrowBase arrow in _listArows)
            {
                if (arrow.GetType() == typeof(T))
                {
                    return Instantiate(arrow, transform.position + new Vector3(1, 0.5f, 0), transform.rotation, transform);
                }
            }

            return null;
        }
    }
}
