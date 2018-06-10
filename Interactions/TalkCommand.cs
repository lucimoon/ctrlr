using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCommand : DialogueCommand {
  public override void Execute()
  {
    controller.Talk();
  }
}