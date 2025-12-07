using System;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class DirectionComparer : MonoBehaviour
{
   [SerializeField] private Transform _windDirection;
   [SerializeField] private Transform _sailDirection;
   public float DirectionDot { get; private set; }
   private void Update()
   {
      DirectionDot = Vector3.Dot(_sailDirection.forward, _windDirection.forward);
      Debug.Log(DirectionDot);
   }
}