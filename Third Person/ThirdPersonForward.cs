using UnityEngine;
using System.Collections;

public class ThirdPersonForward : ThirdPersonCommand
{
  public override void Execute()
  {
    controller.Move(Direction.forward);
  }
}
