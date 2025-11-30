using System;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
  [SerializeField] private Material _hovered;
  [SerializeField] private Material _idle;
  [SerializeField] private LayerMask _groundMask;
  [SerializeField] private LayerMask _objectMask;
  private Ray CustomRay;
  private ObjectSelector _selector;
  private InputManager _input;
  private ObjectMover _mover;
  private Box _selectedBox;
  private void Awake()
  {
    _selector = new ObjectSelector(_idle,_hovered);
    _input = new InputManager();
    _mover = new ObjectMover();
  }

  private void Update()
  {
    if (GetHit(_objectMask, out RaycastHit objectHit))
    {
      _selector.SelectObject(objectHit);
      if (_input.MouseLeftDown)
      {
        _mover.PickUpObject(objectHit.transform);
      }
    }
    else
    {
      _selector.DeselectObject();
    }

    if (_input.MouseLeftHold && GetHit(_groundMask, out RaycastHit groundHit))
    {
      _mover.MoveObject(groundHit.point);
    }

    if (_input.MouseLeftUp)
    {
      _mover.ReleaseObject();
    }
    if (!_mover.Dragged)
    {
      _selector.DeselectObject();
    }
  }

  private bool GetHit(LayerMask mask, out RaycastHit hit)
  {
    CustomRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    return (Physics.Raycast(CustomRay,out hit, Mathf.Infinity,mask));
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.darkRed;
    Gizmos.DrawRay(CustomRay.origin,CustomRay.direction * 100f);
    if (GetHit(_groundMask, out RaycastHit hitt))
    {
      Gizmos.DrawSphere(hitt.point,0.2f);
      
    }
  }
}