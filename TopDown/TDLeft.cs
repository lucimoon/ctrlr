using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts
{
    public class TDLeft : TDCommand
    {
        public override void Execute()
        {
            Debug.Log("Left");
            controller.Move(Direction.left);
        }
    }
}