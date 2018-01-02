using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts.Ctrlr.Projectile
{
    public class ProjectileCommand : Command
    {

        protected ProjectileController controller;

        protected override void Start()
        {
            base.Start();
            this.controller = GetComponent<ProjectileController>();
        }
    }
}