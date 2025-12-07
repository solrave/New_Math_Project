using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WindController : MonoBehaviour
{
   [SerializeField] private Transform _windDirection;
   [SerializeField] private float _windMaxAngle;
   [SerializeField] private float _windMinAngle;
   [SerializeField] private float _windRotationSpeed;
   private float _windTarget;
   private float _currentWind;
   private Quaternion _targetRotation;
   private Quaternion _currentRotation;
   public Vector3 Direction => _windDirection.forward;

   private void Start()
   {
      SetTargetWindRotation();
   }

   private void Update()
   {
      RotateWind();
      ChackIfTargetReached();
   }

   private void RotateWind()
   {
      var step = _windRotationSpeed * Time.deltaTime;
      _windDirection.rotation =
         Quaternion.RotateTowards(_windDirection.rotation,_targetRotation ,step);
   }

   private void SetTargetWindRotation()
   {
      _targetRotation = Quaternion.Euler(0,Random.Range(_windMinAngle, _windMaxAngle),0 );
   }

   private void ChackIfTargetReached()
   {
      if (Quaternion.Angle(_windDirection.rotation,_targetRotation) < 0.1f)
      {
         SetTargetWindRotation();
      }
   }
}