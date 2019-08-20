using UnityEngine;
using System.Collections;

public class UIToggle : UICommand
{
  public override void Execute() {
    controller.ToggleUI();
  }
}