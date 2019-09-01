using UnityEngine;
using System.Collections;

public class ThirdPersonFixedRight : ThirdPersonMove
{
  public override void Execute()
  {
    base.Execute();
    controller.Move(Direction.right);
  }
}
