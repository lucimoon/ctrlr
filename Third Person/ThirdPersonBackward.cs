using UnityEngine;
using System.Collections;

public class ThirdPersonBackward : ThirdPersonCommand
{
  public override void Execute()
  {
    controller.Move(Direction.backward);
  }
}
