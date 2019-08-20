using UnityEngine;
using System.Collections;

public class ThirdPersonLeft : ThirdPersonCommand
{
  public override void Execute()
  {
    base.Execute();
    controller.Move(Direction.left);
  }
}
