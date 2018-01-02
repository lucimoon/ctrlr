using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts.Ctrlr.TopDown
{
    public class TDUp : TDCommand, ICommand
    {
        private KeyCode defaultKeyCode = KeyCode.W;

        protected override void Start()
        {
            base.Start();
            commander.CommandMap.Add(defaultKeyCode, this);
        }

        public void Execute()
        {
            Debug.Log("Up execution");
            controller.Move(Direction.up);
        }
    }
}