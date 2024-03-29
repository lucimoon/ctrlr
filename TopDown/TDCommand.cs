using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts
{
  public class TDCommand : Command
  {

    protected TopDownController controller;

    protected override void Start()
    {
      base.Start();
      this.controller = GetComponent<TopDownController>();
    }
  }
}