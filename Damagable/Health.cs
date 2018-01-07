using UnityEngine;
using UnityEngine.UI;

namespace tardigrage_alpha.Assets.Scripts
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField]
        private float health = 100f;
        [SerializeField]
        private Slider healthSlider;

        void Start() {
          UpdateUI();
        }

        public void Reduce(float damage) {
          health -= Mathf.Abs(damage);;
          Debug.Log("health: " + health);
          if (health <= 0f) Kill();

          UpdateUI();
        }

        private void Kill () {
            Destroy(gameObject);
        }

        private void UpdateUI () {
          if (healthSlider != null) {
            healthSlider.value = health;
          }
        }
    }
}