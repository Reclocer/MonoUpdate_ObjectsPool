using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoUpdate
{
    public class ArrowFactory : MonoUpdateClass
    {
        [SerializeField] private List<ArrowBase> _listArows;

        public ArrowBase CreateArrow<T>() where T : ArrowBase
        {
            foreach (ArrowBase arrow in _listArows)
            {
                if (arrow.GetType() == typeof(T))
                {
                    return Instantiate(arrow, transform.position, transform.rotation, transform);
                }
            }

            Debug.LogWarning("ArrowFactory cant create arrow. Please add arrow to 'List Arrows' ");
            return null;
        }
    }
}

