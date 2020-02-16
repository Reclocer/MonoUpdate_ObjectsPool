using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandartUpdate
{
    public class OnDestroyTrigger : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}
