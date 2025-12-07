using System;
using Unity.Mathematics;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _sailSpeed;
    [SerializeField] private Transform _sail;
    [SerializeField] private DirectionComparer _directionComparer;
    private InputManager _input;
    private float _shipRotation;
    private float _sailRotation;
    
    private void Start()
    {
        _input = new InputManager();
    }

    private void Update()
    {
        GetRotation();
        RotateShip();
        RotateSail();
        MoveShip();
    }


    private void MoveShip()
    {
        if (_directionComparer.DirectionDot <= 0) return;
        
        if ((_sail.rotation.y > 85f || _sail.rotation.y < -85f) && (_directionComparer.DirectionDot > 0))
        return;
        
        var speed = _directionComparer.DirectionDot * _sailSpeed * Time.deltaTime;
        transform.Translate(0,0,speed);
    }

    private void GetRotation()
    {
        float nextRotation;
        _shipRotation += Input.GetAxis("Horizontal") * _turnSpeed * Time.deltaTime; 
        _sailRotation += _input.sailRotation * _turnSpeed * Time.deltaTime;
    }
    private void RotateShip()
    {
        transform.rotation = Quaternion.Euler(0,_shipRotation,0);
        //transform.Rotate(Vector3.up, _shipRotation);
    }

    private void RotateSail()
    {
        _sailRotation = Mathf.Clamp(_sailRotation, -90f, 90f);
        _sail.localRotation = Quaternion.Euler(0, _sailRotation, 0);
    }
}
