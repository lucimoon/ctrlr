using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts.Ctrlr.Projectile
{
  public class Projectile : MonoBehaviour
  {
    public float speed = 10f;
    public float damage = 10f;

    void OnEnable()
    {
      Rigidbody objectRigidbody = transform.GetComponent<Rigidbody>();
      objectRigidbody.velocity = transform.up * speed;
    }

    void OnBecameInvisible()
    {
      Deactivate();
    }

    void OnTriggerEnter(Collider otherCollider)
    {
      Health otherHealth = otherCollider.gameObject.GetComponent<Health>();
      if (otherHealth == null) return;

      otherHealth.Reduce(damage);
      Deactivate();
    }

    private void Deactivate() {
      gameObject.SetActive(false);
    }
  }
}