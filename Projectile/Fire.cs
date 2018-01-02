using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts.Ctrlr.Projectile
{
    public class Fire : ProjectileCommand, ICommand
    {

        public KeyCode keyCode = KeyCode.Mouse0;

        protected override void Start()
        {
            base.Start();
            commander.CommandMap.Add(keyCode, this);
        }

        public void Execute()
        {
            controller.Fire();
        }
    }
}