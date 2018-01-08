using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts
{
    public class Fire : ProjectileCommand
    {
      [SerializeField]
      private float rateLimitInSeconds = 0f;
      private bool allowFire = true;

      public override void Execute()
      {
        if (allowFire) {
          StartCoroutine(LimitedFire());
        }
      }

      private IEnumerator LimitedFire() {
          allowFire = false;
          this.controller.Fire();
          yield return new WaitForSeconds(rateLimitInSeconds);
          allowFire = true;
      }
    }
}