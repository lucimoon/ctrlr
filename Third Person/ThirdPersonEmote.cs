using UnityEngine;
using System.Collections;

public class ThirdPersonEmote : ThirdPersonCommand
{
  public override void Execute()
  {
    controller.Emote();
  }
}
