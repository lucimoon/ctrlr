using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts
{
  public class Projectile : MonoBehaviour
  {
    public float speed = 10f;

    protected virtual void OnEnable()
    {
      Rigidbody objectRigidbody = transform.GetComponent<Rigidbody>();
      objectRigidbody.velocity = transform.forward * speed;
    }

    void OnBecameInvisible()
    {
      Deactivate();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
      Deactivate();
    }

    private void Deactivate() {
      gameObject.SetActive(false);
    }
  }
}