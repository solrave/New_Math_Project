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
  private RaycastHit _currentHit;
  private LayerMask _currentMask;
  private IDraggable _currentDraggable;
  private ISelectable _currentSelectable;

  private void Awake()
  {
    _selector = new ObjectSelector(_idle,_hovered);
    _input = new InputManager();
    _mover = new ObjectMover();
    _currentMask = _objectMask;
  }

  private void Update()
  {
    SetMask();
    CastRay(_currentMask);
    ExtractInterface();
    HighlightCurrent();
  }

  private void SetMask()
  {
    if (_currentDraggable != null)
      _currentMask = _groundMask;

    _currentMask = _objectMask;
  }

  private void CastRay(LayerMask mask)
  {
    CustomRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    Physics.Raycast(CustomRay,out _currentHit,Mathf.Infinity,mask);
  }

  private void ExtractInterface()
  {
    if (_currentHit.transform != null)
    {
      if (_currentHit.transform.TryGetComponent<ISelectable>(out ISelectable selectable))
      {
        _currentSelectable = selectable;
        _currentSelectable.Selected = true;
      }
      if (_currentHit.transform.TryGetComponent<IDraggable>(out IDraggable draggable))
      {
        _currentDraggable = draggable;
      }
    }
  }

  private void HighlightCurrent()
  {
    if (_currentSelectable.Selected)
    {
      _currentSelectable?.Select(_hovered);
    }
    if (_currentHit.transform.TryGetComponent<ISelectable>(out ISelectable newSelectable))
    {
      if (_currentSelectable != newSelectable)
      {
        _currentSelectable.Selected = false;
        _currentSelectable?.Select(_idle);
        _currentSelectable = newSelectable;
      }
    }
  }
  

  // private void OnDrawGizmos()
  // {
  //   Gizmos.color = Color.darkRed;
  //   Gizmos.DrawRay(CustomRay.origin,CustomRay.direction * 100f);
  //   GetHit(_groundMask);
  //   Gizmos.DrawSphere(hitt.point,0.2f);
  // }
}