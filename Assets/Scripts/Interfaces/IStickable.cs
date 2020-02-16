using UnityEngine;

public interface IStickable 
{
    int MaxStickObjects { get; }
    Rigidbody SticableBody { get;}

    void StickObject(Rigidbody rigidbody);
    void UnStick(Rigidbody rigidbody);
}
