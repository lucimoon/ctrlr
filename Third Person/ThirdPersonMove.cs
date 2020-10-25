using UnityEngine;
using System.Collections;

public class ThirdPersonMove : ThirdPersonCommand
{
  protected override void Start() {
    base.Start();
    this.disabledOnKeyUp = true;
  }

  public override void Execute()
  {
    controller.UpdateAnimationState("isMoving", true);
  }

  protected override void After() {
    controller.UpdateAnimationState("isMoving", false);
  }
}