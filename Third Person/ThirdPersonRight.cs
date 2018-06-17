using UnityEngine;
using System.Collections;

public class ThirdPersonRight : ThirdPersonCommand 
{
  public override void Execute()
  {
    base.Execute();
    controller.Move(Direction.right);
  }
}
