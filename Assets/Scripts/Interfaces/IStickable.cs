using UnityEngine;

public interface IStickable 
{
    int MaxStickObjects { get; }

    void StickObject(Rigidbody rigidbody);    
}
