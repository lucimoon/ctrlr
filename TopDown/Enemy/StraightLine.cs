using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts
{
  public class StraightLine : TDCommand
  {
    Camera mainCamera;

    protected override void Start()
    {
      base.Start();
      mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    public void Update()
    {
      Vector3 viewportPosition = mainCamera.WorldToViewportPoint(gameObject.transform.position);

      if (viewportPosition.x < -0.1f) {
        controller.Die();
      }
    }

    public override void Execute()
    {
      controller.Move(Direction.left);
    }
  }
}