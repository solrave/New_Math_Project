using UnityEngine;

public class InputManager
{
  public bool MouseLeftHold => Input.GetMouseButton(0);
  public bool MouseLeftDown => Input.GetMouseButtonDown(0);
  public bool MouseLeftUp => Input.GetMouseButtonUp(0);
}