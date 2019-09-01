using UnityEngine;
using System.Collections;

public class ThirdPersonFixedLeft : ThirdPersonMove
{
  public override void Execute()
  {
    base.Execute();
    controller.Move(Direction.left);
  }
}
