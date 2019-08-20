using UnityEngine;
using System.Collections;

public class ThirdPersonHold : ThirdPersonCommand
{
  public override void Execute()
  {
    controller.Hold();
  }
}
