using UnityEngine;
using System.Collections;

public class ThirdPersonForward : ThirdPersonMove
{
  public override void Execute()
  {
    base.Execute();
    controller.Move(Direction.forward);
  }
}
