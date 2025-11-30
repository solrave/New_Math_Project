using UnityEngine;
using Input = UnityEngine.Windows.Input;

public class ObjectMover
{
  private IDraggable draggable;
  public bool Dragged => draggable != null;
  public void MoveObject(Vector3 point)
  {
    draggable?.Move(point);
  }

  public void PickUpObject(Transform transform)
  {
    if (transform.TryGetComponent<IDraggable>(out draggable))
    {
      draggable.PickUp();
    }
  }

  public void ReleaseObject()
  {
    draggable?.Release();
    draggable = null;
  }
  
}