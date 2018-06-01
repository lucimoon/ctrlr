using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts
{
  public class TDLeft : TDCommand
  {
    public override void Execute()
    {
      controller.Move(Direction.left);
    }
  }
}