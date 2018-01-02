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
            this.commander.CommandMap.Add(keyCode, this);
        }

        public void Execute()
        {
            this.controller.Fire();
        }
    }
}