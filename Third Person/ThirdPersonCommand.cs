using UnityEngine;
using System.Collections;

public class ThirdPersonCommand : Command
{

  protected ThirdPersonController controller;

  protected override void Start()
  {
    base.Start();
    this.controller = GetComponent<ThirdPersonController>();
  }
}