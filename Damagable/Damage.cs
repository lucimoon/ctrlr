using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts
{
  public class Damage : MonoBehaviour
  {
    [SerializeField]
    private float damage = 10f;

    void OnTriggerEnter(Collider otherCollider)
    {
      Health otherHealth = otherCollider.gameObject.GetComponent<Health>();
      if (otherHealth == null) return;

      otherHealth.Reduce(damage);
    }

  }
}