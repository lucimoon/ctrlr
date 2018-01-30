using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField]
        private float health = 100f;
        [SerializeField]
        private Slider healthSlider;
        private Color originalColor;
        private Renderer objectRenderer;
        private Color damageColor;

        void Start() {
          UpdateUI();
          PrepDamageAnimation();
        }

        public void Reduce(float damage) {
          health -= Mathf.Abs(damage);;
          if (health <= 0f) Kill();

          UpdateUI();
          StartCoroutine(AnimateDamage());
        }

        private void Kill () {
            Destroy(gameObject);
        }

        private void UpdateUI () {
          if (healthSlider != null)
          {
            healthSlider.value = health;
          }
        }

        private void PrepDamageAnimation () {
          objectRenderer = GetComponent<Renderer>();

          if (objectRenderer == null)
          {
            objectRenderer = gameObject.GetComponentInChildren<Renderer>();
          }

          originalColor = objectRenderer.material.color;
          damageColor = Color.red;
        }

        private IEnumerator AnimateDamage () {
          objectRenderer.material.color = damageColor;

          while (objectRenderer.material.color != originalColor)
          {
            objectRenderer.material.color = Color.Lerp(objectRenderer.material.color, originalColor, 10f * Time.deltaTime);
            yield return null;
          }
        }
    }
}