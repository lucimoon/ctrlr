using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ThirdPersonBackward))]
[RequireComponent(typeof(ThirdPersonForward))]
[RequireComponent(typeof(ThirdPersonLeft))]
[RequireComponent(typeof(ThirdPersonRight))]
public class ThirdPersonController : MonoBehaviour
{
  [SerializeField]
  private float speed = 10f;

  private Dictionary<Direction, Vector3> directionMap = new Dictionary<Direction, Vector3>
  {
    {Direction.forward, Vector3.forward},
    {Direction.backward, Vector3.back},
    {Direction.left, Vector3.left},
    {Direction.right, Vector3.right},
  };

  public void Move (Direction direction) {
    if (directionMap.ContainsKey(direction)) {
      Vector3 vector = directionMap[direction] * speed * Time.deltaTime;
      transform.Translate(vector, Space.World);
    }
  }

  public void Spawn()
  {
    EventManager.TriggerEvent("spawn-start");
    StartCoroutine(StartSequence());
  }

  public void Die()
  {
    gameObject.SetActive(false);
  }

  private IEnumerator StartSequence()
  {
    yield return null;
    EventManager.TriggerEvent("spawn-end");
  }
}
