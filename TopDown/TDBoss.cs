using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts
{
  public class TDBoss : TDCommand
  {
    [SerializeField]
    private Camera mainCamera;

    protected override void Start () {
      base.Start();
      AttachCamera();
      if (mainCamera == null) Debug.LogWarning("Attach main camera to TDBoss command for positioning.");
    }

    public override void Execute()
    {
      if(!InPosition()) {
        controller.Move(Direction.left);
      }
    }

    private void AttachCamera () {
      if (mainCamera == null) {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
      }
    }

    private bool InPosition() {
      bool inPosition = false;
      Vector3 bossPosition = mainCamera.WorldToViewportPoint(gameObject.transform.position);

      if (bossPosition.x < 0.9f) inPosition = true;

      Debug.Log("bossPosition.x : " + bossPosition.x );
      Debug.Log("inPosition: " + inPosition);
      return inPosition;
    }
  }
}