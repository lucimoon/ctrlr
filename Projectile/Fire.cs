using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts.Ctrlr.Projectile
{
    public class Fire : ProjectileCommand
    {
        public override void Execute()
        {
            this.controller.Fire();
        }
    }
}