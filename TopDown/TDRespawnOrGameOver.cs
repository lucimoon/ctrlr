using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts
{
  public class TDRespawnOrGameOver : TDCommand
  {
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Health health;

    protected override void Start ()
    {
      base.Start();
      LogWarnings();
    }

    public override void Execute()
    {
      if (health != null && health.Lives <= 0)
      {
        EventManager.TriggerEvent("game-over");
        return;
      }

      controller.Spawn();
    }

    private void LogWarnings() {
      if (health == null) Debug.LogWarning("Attach Health to TDRespawnOrGameOver");
    }
  }
}