using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandartUpdate
{
    public class ArrowInitializer : MonoBehaviour
    {
        [SerializeField] private ArrowFactory _arrowFactory;

        // Start is called before the first frame update
        void Start()
        {
            _arrowFactory.CreateArrow<Arrow>();
            _arrowFactory.CreateArrow<FireArrow>();
        }
    }
}
