using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts.Ctrlr.TopDown
{
    public class TDDown : TDCommand
    {
      public override void Execute()
      {
        Debug.Log("Down");
        controller.Move(Direction.down);
      }
    }
}