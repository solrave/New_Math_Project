using System;
using UnityEngine;

public class Box : MonoBehaviour, IDragable, ISelectable
{
  [SerializeField] private Material _selected;
  [SerializeField] private Material _idle;
  private Rigidbody _rb;
  private MeshRenderer _mr;
  private bool _isHit;
  
  private void Awake()
  {
    _rb = transform.GetComponent<Rigidbody>();
    _mr = transform.GetComponent<MeshRenderer>();
  }

  public void PickUp()
  {
    _rb.isKinematic = true;
   transform.position = new Vector3(transform.position.x, 1, transform.position.z);
  }

  public void Move(Vector3 point)
  {
    _rb.MovePosition(new Vector3(point.x,transform.position.y,point.z));
  }

  public void Release()
  {
    _rb.isKinematic = false;
    _rb.AddForce(0,-1,0);
  }


  public void Select()
  {
    Debug.Log("Selected!");
    _mr.material = _selected;
  }

  public void Deselect()
  {
    _mr.material = _idle;
  }
}