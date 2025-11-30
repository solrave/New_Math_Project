using System;
using UnityEngine;

public class ObjectSelector
{
  private readonly Material _idle;
  private readonly Material _hovered;
  private ISelectable _selectedObject;
 
  private LayerMask _mask;

  public ObjectSelector(Material idle, Material hovered)
  {
    _idle = idle;
    _hovered = hovered;
  }

  public void SelectObject(RaycastHit hit)
  {
      if (hit.transform.TryGetComponent<ISelectable>(out ISelectable selected))
      {
        _selectedObject = selected;
        _selectedObject.Select(_hovered);
      }
  }

  public void DeselectObject()
  {
    if (_selectedObject is not null)
    {
      _selectedObject.Select(_idle);
      _selectedObject = null;
    }
  }
}