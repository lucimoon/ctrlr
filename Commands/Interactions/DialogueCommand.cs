using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCommand : Command {
    protected DialogueController controller;

    protected override void Start()
    {
        base.Start();
        this.controller = GetComponent<DialogueController>();
    }
}
