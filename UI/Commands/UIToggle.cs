using UnityEngine;
using System.Collections;

public class UIToggle : UICommand
{
  public override void Execute() {
    Debug.Log(controller);
    controller.ToggleUI();
  }
}