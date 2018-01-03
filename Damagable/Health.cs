using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField]
        private float health = 100f;

        public void Reduce(float damage) {
          health -= Mathf.Abs(damage);;
          Debug.Log("health: " + health);
          if (health <= 0f) Kill();
        }

        private void Kill () {
            Destroy(gameObject);
        }
    }
}