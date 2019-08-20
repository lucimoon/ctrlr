using UnityEngine;
using System.Collections;

public class ProjectileCommand : Command
{

    protected ProjectileController controller;

    protected override void Start()
    {
        base.Start();
        this.controller = GetComponent<ProjectileController>();
    }
}