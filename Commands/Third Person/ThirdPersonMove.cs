using UnityEngine;
using System.Collections;

public class ThirdPersonMove : ThirdPersonCommand
{
  [SerializeField]
  private string animatorBool = "isMoving";

  protected override void Start() {

    base.Start();
    this.disabledOnKeyUp = true;
  }

  public override void Execute()
  {
    controller.UpdateAnimatorBool(animatorBool, true);
  }

  protected override void After() {
    controller.UpdateAnimatorBool(animatorBool, false);
  }
}