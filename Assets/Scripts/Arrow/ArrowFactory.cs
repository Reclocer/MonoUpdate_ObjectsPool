using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFactory : MonoBehaviour
{
    [SerializeField] private List<ArrowBase> _listArows;

    public ArrowBase CreateArrow<T>() where T : ArrowBase
    {
        foreach(ArrowBase arrow in _listArows)
        {
            if(arrow.GetType() == typeof(T))
            {
                return Instantiate(arrow);
            }            
        }

        return null;
    }
}
