using UnityEngine;
public interface IDragable
{
    void PickUp();
    void Move(Vector3 point);
    void Release();
}