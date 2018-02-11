using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts
{
  public class Fire : ProjectileCommand
  {
    public float fireRate = 0f;
    public int burstLimit = 3;
    public float rechargeTime = 3f;

    private int burstCounter = 0;
    private bool allowFire;

    void OnEnable()
    {
      allowFire = true;
    }

    public override void Execute()
    {
      if (allowFire) {
        StartCoroutine(LimitedFire());
      }
    }

    private IEnumerator LimitedFire() {
      allowFire = false;
      this.controller.Fire();

      if (burstLimit > 0) {
        burstCounter++;

        if (burstCounter >= burstLimit) {
          burstCounter = 0;
          yield return new WaitForSeconds(rechargeTime);
        }
      }

      yield return new WaitForSeconds(fireRate);
      allowFire = true;
    }
  }
}