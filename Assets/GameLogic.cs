using System;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
  [SerializeField] private LayerMask _groundMask;
  [SerializeField] private LayerMask _objectMask;
  [SerializeField] private GameObject _box;
  [SerializeField] private GameObject _pyramid;
  private Ray CustomRay;
  private ObjectSelector _selector;
  private InputManager _input;
  private ObjectMover _mover;
  private RaycastHit _groundHit;
  private RaycastHit _objectHit;
  private bool _isGroundHit;
  private bool _isObjectHit;

  private void Awake()
  {
    _selector = new ObjectSelector();
    _input = new InputManager();
    _mover = new ObjectMover();
  }

  private void Update()
  {
    CastRay();
    SelectObject();
    ProcessHit();
    InstantiateObject();
  }

  private void InstantiateObject()
  {
    if (_input.SpaceClick && _isGroundHit)
    {
      var position = new Vector3(_groundHit.point.x, _groundHit.point.y + 0.5f, _groundHit.point.z);
      Instantiate(_box, position, Quaternion.identity);
    }
  }
  
  private void ProcessHit()
  {
    if (_input.MouseLeftDown && _isObjectHit)
    {
      _mover.PickUpObject(_objectHit.transform);
    }
    
    if (_input.MouseLeftHold && _mover.DragInProgress && _isGroundHit)
    {
      _mover.MoveObject(_groundHit.point);
    }

    if (_input.MouseLeftUp && _mover.DragInProgress)
    {
      _mover.ReleaseObject();
      _selector.DeselectObject();
    }
  }
  
  private void CastRay()
  {
    CustomRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    _isGroundHit = Physics.Raycast(CustomRay,out _groundHit,Mathf.Infinity,_groundMask);
    _isObjectHit = Physics.Raycast(CustomRay,out _objectHit,Mathf.Infinity,_objectMask);
  }
  
  private void SelectObject()
  {
    if (_mover.DragInProgress) return;
    
    if (_isObjectHit)
    {
      _selector.SelectObject(_objectHit.transform);
    }
    else
    {
      _selector.DeselectObject();
    }
  }
}