using UnityEngine;

public class InputManager
{
  public bool MouseLeftHold => Input.GetMouseButton(0);
  public bool MouseLeftDown => Input.GetMouseButtonDown(0);
  public bool MouseRightDown => Input.GetMouseButtonDown(1);
  public bool MouseLeftUp => Input.GetMouseButtonUp(0);

  public bool SpaceKeyDown => Input.GetKeyDown(KeyCode.Space);
  public bool VKeyDown => Input.GetKeyDown(KeyCode.V);
}