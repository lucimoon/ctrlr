using UnityEngine;
using System.Collections;

public class ThirdPersonInteract : ThirdPersonCommand
{
  public override void Execute()
  {
    controller.Interact();
  }
}
