using System.Collections.Generic;
using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts.Ctrlr.Projectile {
  [RequireComponent(typeof(Fire))]

  public class ProjectileController : MonoBehaviour {
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private int maxProjectiles = 20;
    [SerializeField]
    private Projectile projectile;
    private ObjectPool pool;
    bool INTSTANTIATE_IN_WORLD_SPACE = true;

    void Start () {
      if (projectile != null) {
        SetProjectileSpeed();
        InitializePool();
      }
    }

    public void Fire () {
      GameObject currentProjectile = pool.GetPooledObject();
      if (currentProjectile == null) return;

      currentProjectile.transform.position = gameObject.transform.position;
      currentProjectile.transform.rotation = gameObject.transform.rotation;
      currentProjectile.SetActive(true);
    }

    private void InitializePool () {
      pool = gameObject.AddComponent<ObjectPool>();
      pool.objectToPool = projectile.gameObject;
      pool.amountToPool = maxProjectiles;
      pool.FillPool();
    }

    private void SetProjectileSpeed () {
      projectile.speed = speed;
    }
  }
}