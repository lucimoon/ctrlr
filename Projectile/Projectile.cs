using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts
{
  public class Projectile : MonoBehaviour
  {
    public float speed = 10f;

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
      Deactivate();
    }

    private void Deactivate() {
      gameObject.SetActive(false);
    }
  }
}