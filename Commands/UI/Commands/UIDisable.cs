using UnityEngine;
using System.Collections;

public class UIDisable : UICommand
{
  public override void Execute() {
    controller.DisableUI();
  }
}