using UnityEngine;
using System.Collections;

public class UIEnable : UICommand
{
  public override void Execute() {
    controller.EnableUI();
  }
}