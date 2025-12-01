using System;
using UnityEngine;

public class ObjectSelector
{
  private readonly Material _idle;
  private readonly Material _hovered;
  private LayerMask _mask;

  public ObjectSelector(Material idle, Material hovered)
  {
    _idle = idle;
    _hovered = hovered;
  }

  public void SelectObject(ISelectable selectable)
  {
    selectable.Select(_hovered);
  }

  public void DeselectObject(ISelectable selectable)
  {
    if (selectable is not null)
    {
      selectable.Select(_idle);
    }
  }
}