using UnityEngine;
using System.Collections;

public class ThirdPersonBackward : ThirdPersonMove
{
  public override void Execute()
  {
    base.Execute();
    controller.Move(Direction.backward);
  }
}

