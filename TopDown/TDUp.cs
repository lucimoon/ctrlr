using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts
{
    public class TDUp : TDCommand
    {
        public override void Execute()
        {
            Debug.Log("Up");
            controller.Move(Direction.up);
        }
    }
}