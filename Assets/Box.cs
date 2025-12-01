using System;
using UnityEngine;

public class Box : MonoBehaviour, IDraggable, ISelectable
{
  public bool Selected { get; set; }
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
    _rb.transform.position = (new Vector3(point.x,transform.position.y,point.z));
    //_rb.transform.position = point;
  }

  public void Release()
  {
    _rb.isKinematic = false;
    _rb.AddForce(0,-1,0);
  }


  public void Select(Material material)
  {
    _mr.material = material;
  }
  
}