using System;
using UnityEngine;

public class ObjectSelector
{
  private LayerMask _mask;
  private ISelectable _currentSelectable;

  public void SelectObject(Transform transform)
  {
    if (transform.TryGetComponent<ISelectable>(out var selectable))
    {
      DeselectObject();
      _currentSelectable = selectable;
      _currentSelectable.Select();
    }
  }

  public void DeselectObject()
  {
    _currentSelectable?.Deselect();
    _currentSelectable = null;
  }
}