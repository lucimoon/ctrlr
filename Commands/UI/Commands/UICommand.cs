using UnityEngine;
using System.Collections;

public class UICommand : Command
{
  protected UIController controller;

  protected override void Start()
  {
    base.Start();
    this.controller = GetComponent<UIController>();
  }
}