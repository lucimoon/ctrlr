using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts
{
    public class TDRight : TDCommand
    {
        public override void Execute()
        {
            controller.Move(Direction.right);
        }
    }
}