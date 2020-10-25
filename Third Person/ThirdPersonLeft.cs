using UnityEngine;
using System.Collections;

public class ThirdPersonLeft : ThirdPersonMove
{
  public override void Execute()
  {
    base.Execute();
    controller.Move(Direction.left);
  }
}
