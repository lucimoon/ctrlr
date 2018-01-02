using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts.Ctrlr.TopDown
{
    public class TDLeft : TDCommand, ICommand
    {
        private KeyCode defaultKeyCode = KeyCode.A;

        protected override void Start()
        {
            base.Start();
            commander.CommandMap.Add(defaultKeyCode, this);
        }

        public void Execute()
        {
            Debug.Log("Up execution");
            controller.Move(Direction.left);
        }
    }
}