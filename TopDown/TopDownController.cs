using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace tardigrage_alpha.Assets.Scripts
{
  [RequireComponent(typeof(TDDown))]
  [RequireComponent(typeof(TDUp))]
  [RequireComponent(typeof(TDLeft))]
  [RequireComponent(typeof(TDRight))]
  [RequireComponent(typeof(TDBoss))]
  public class TopDownController : MonoBehaviour
  {
    [SerializeField]
    protected Camera mainCamera;

    [SerializeField]
    public ParticleSystem deathParticlesPrefab;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private bool spawnOnStart = false;

    [SerializeField]
    private float spawnInvincibilityTime = 2f;

    [SerializeField]
    private bool keepWithinBounds = false;

    private float distanceFromCamera;
    private Dictionary<Direction, Vector3> directionMap = new Dictionary<Direction, Vector3>
    {
      {Direction.up, Vector3.up},
      {Direction.down, Vector3.down},
      {Direction.left, Vector3.left},
      {Direction.right, Vector3.right},
    };


    void Start() {
      if (mainCamera != null) distanceFromCamera = gameObject.transform.position.z - mainCamera.transform.position.z;
      if (spawnOnStart) Spawn();
    }

    public void Move (Direction direction) {
      bool withinBounds = GetWithinBounds(direction);

      if (directionMap.ContainsKey(direction) && withinBounds) {
        Vector3 vector = directionMap[direction] * speed * Time.deltaTime;
        transform.Translate(vector, Space.World);
      }
    }

    private bool GetWithinBounds(Direction direction) {
      bool withinBounds = true;

      if (!keepWithinBounds) return withinBounds;

      Vector3 viewportPosition = mainCamera.WorldToViewportPoint(gameObject.transform.position);

      switch (direction)
      {
        case Direction.left:
          withinBounds = viewportPosition.x > 0;
          break;
        case Direction.right:
          withinBounds = viewportPosition.x < 1;
          break;
        case Direction.up:
          withinBounds = viewportPosition.y < 1;
          break;
        case Direction.down:
          withinBounds = viewportPosition.y > 0;
          break;
        default:
          break;
      }

      return withinBounds;
    }

    public void Spawn()
    {
      EventManager.TriggerEvent("spawn-start");
      gameObject.GetComponent<Collider>().enabled = false;
      gameObject.transform.position = mainCamera.ViewportToWorldPoint(new Vector3(-0.1f, 0.5f, distanceFromCamera));

      gameObject.SetActive(true);
      StartCoroutine(StartSequence());
      StartCoroutine(EnableCollisionsIn(spawnInvincibilityTime));
    }

    public void Die()
    {
      Splash();
      gameObject.SetActive(false);
    }

    private IEnumerator StartSequence()
    {
      Vector3 startPostion = mainCamera.ViewportToWorldPoint(new Vector3(0.1f, 0.5f, distanceFromCamera));
      while (gameObject.transform.position != startPostion) {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, startPostion, speed * Time.deltaTime);
        yield return null;
      }

      EventManager.TriggerEvent("spawn-end");
    }

    private IEnumerator EnableCollisionsIn(float seconds)
    {
      yield return new WaitForSeconds(seconds);
      gameObject.GetComponent<Collider>().enabled = true;
    }

    private void Splash () {
      if (deathParticlesPrefab != null) {
        ParticleSystem deathParticles = Instantiate(deathParticlesPrefab, gameObject.transform.position, Quaternion.identity);
        deathParticles.Play();
      }
    }
  }
}
