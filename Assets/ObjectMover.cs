using UnityEngine;
using Input = UnityEngine.Windows.Input;

public class ObjectMover
{
  private IDragable _dragable;
  public bool DragInProgress => _dragable != null;
  public void MoveObject(Vector3 point)
  {
    _dragable?.Move(point);
  }

  public void PickUpObject(Transform transform)
  {
    if (transform.TryGetComponent<IDragable>(out var dragable))
    {
      _dragable?.Release();
      _dragable = dragable;
      _dragable.PickUp();
    }
  }

  public void ReleaseObject()
  {
    _dragable?.Release();
    _dragable = null;
  }
  
}