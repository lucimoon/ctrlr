using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDialogueCommand : DialogueCommand {
  public override void Execute()
  {
    controller.ExitDialogue();
  }
}