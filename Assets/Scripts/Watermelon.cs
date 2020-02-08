using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour, IStickable
{
    [SerializeField] private int _maxStickObjects = 10;
    public int MaxStickObjects => _maxStickObjects;

    private List<Rigidbody> _listObjects = new List<Rigidbody>();

    private void Update()
    {
        if (_listObjects.Count > _maxStickObjects)
        {
            transform.DetachChildren();
        }
    }

    public void StickObject(Rigidbody rigidbody)
    {
        _listObjects.Add(rigidbody);
        rigidbody.gameObject.transform.SetParent(transform);
    }   
}
