using UnityEngine;

public class InputManager
{
  public bool MouseLeftHold => Input.GetMouseButton(0);
  public bool MouseLeftDown => Input.GetMouseButtonDown(0);
  public bool MouseRightDown => Input.GetMouseButtonDown(1);
  public bool MouseLeftUp => Input.GetMouseButtonUp(0);

  public bool SpaceKeyDown => Input.GetKeyDown(KeyCode.Space);
  public bool VKeyDown => Input.GetKeyDown(KeyCode.V);

  public float xVal => Input.GetAxis("Horizontal");
  public float yVal => Input.GetAxis("Vertical");
  public float sailRotation
  {
    get
    {
      float value = 0;
      if (Input.GetKey(KeyCode.H))
        value = 1;
      else if (Input.GetKey(KeyCode.G))
        value = -1;
      else
        value = 0;
      return value;
    }
  }
}