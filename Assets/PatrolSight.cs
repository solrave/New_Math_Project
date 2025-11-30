using System;
using UnityEngine;

public class PatrolSight : MonoBehaviour
{
    private AngleCheck _check;
    [SerializeField] private Transform _target;
    [SerializeField] private float _angle;
    [SerializeField] private Material _mat;
    private Material _idleMat;
    private MeshRenderer _renderer;

    private void Start()
    {
        _check = new AngleCheck(transform, _angle);
        _renderer = _target.GetComponent<MeshRenderer>();
        _idleMat = _renderer.material;
    }

    private void Update()
    {
      if (_check.IfSpotted(_target))
      {
        _target.transform.localScale = new Vector3(2, 2, 2);
        _renderer.material = _mat;
      }
      else
      {
        _target.transform.localScale = new Vector3(1, 1, 1);
        _renderer.material = _idleMat;
      }
      
     
    }
    
    private void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.crimson;
      Gizmos.DrawLine(transform.position, _target.position);
      Gizmos.DrawRay(transform.position, transform.forward * 100f);
    }
}
