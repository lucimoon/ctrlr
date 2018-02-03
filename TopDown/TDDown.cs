using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts
{
    public class TDDown : TDCommand
    {
      public override void Execute()
      {
        controller.Move(Direction.down);
      }
    }
}