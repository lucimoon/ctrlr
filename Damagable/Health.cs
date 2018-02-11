using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts
{
  public class Health : MonoBehaviour, IDamagable
  {
    public TopDownController controller;

    [SerializeField]
    private float health = 100f;

    [SerializeField]
    private int lives = 3;

    [SerializeField]
    private string deathEventName = "life-lost";

    [SerializeField]
    private string damageEventName = "hit";

    [SerializeField]
    private Slider healthSlider;
    private Color originalColor;
    private Renderer objectRenderer;
    private Color damageColor;

    public int Lives {
      get {
        return this.lives;
      }

    }
    void Start() {
      UpdateUI();
      PrepDamageAnimation();
    }

    public void Reduce(float damage) {
      EventManager.TriggerEvent(damageEventName);

      health -= Mathf.Abs(damage);
      UpdateUI();

      if (health <= 0f)
      {
        Kill();
      }
      else
      {
        StartCoroutine(AnimateDamage());
      }
    }

    private void Kill ()
    {
      lives -= 1;

      if (controller != null)
      {
        Debug.Log(lives);
        controller.Die();
      }
      else
      {
        Destroy(gameObject);
      }

      EventManager.TriggerEvent(deathEventName);
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