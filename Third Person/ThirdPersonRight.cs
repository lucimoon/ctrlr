using UnityEngine;
using System.Collections;

public class ThirdPersonRight : ThirdPersonMove
{
  public override void Execute()
  {
    base.Execute();
    controller.Move(Direction.right);
  }
}
