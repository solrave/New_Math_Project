using UnityEngine;
public interface IDraggable
{
    void PickUp();
    void Move(Vector3 point);
    void Release();
}