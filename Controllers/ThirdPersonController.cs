using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(ThirdPersonBackward))]
[RequireComponent(typeof(ThirdPersonForward))]
[RequireComponent(typeof(ThirdPersonLeft))]
[RequireComponent(typeof(ThirdPersonRight))]
[RequireComponent(typeof(ThirdPersonInteract))]
public class ThirdPersonController : MonoBehaviour
{
  [SerializeField]
  protected float movementSpeed = 10f;
  [SerializeField]
  protected float rotationSpeed = 20f;
  [SerializeField]
  protected Transform holdTransform;
  [SerializeField]
  protected Animator animator;

  protected Dictionary<Direction, Vector3> directionMap;
  protected CharacterController controller;
  protected Vector3 leftRotation;
  protected Vector3 rightRotation;

  protected virtual void Start() {
    controller = GetComponent<CharacterController>();

    leftRotation = new Vector3(0f, -10f, 0f);
    rightRotation = new Vector3(0f, 10f, 0f);

    directionMap = new Dictionary<Direction, Vector3>
    {
      {Direction.forward, transform.forward},
      {Direction.backward, -transform.forward},
      {Direction.left, leftRotation},
      {Direction.right, rightRotation},
    };
  }

  public virtual void Move (Direction direction) {
    if (directionMap.ContainsKey(direction)) {
        Vector3 vector = directionMap[direction] * Time.deltaTime;

      if (direction == Direction.forward) {
        controller.SimpleMove(transform.forward * movementSpeed);
      }

      if (direction == Direction.backward) {
        controller.SimpleMove(-transform.forward * movementSpeed);
      }

      if (direction == Direction.left || direction == Direction.right) {
        gameObject.transform.Rotate(vector * rotationSpeed);
      }
    }
  }

  public virtual void Interact () {
  }

  public virtual void Hold () {
  }

  public virtual void Emote() {
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

  protected IEnumerator StartSequence()
  {
    yield return null;
    EventManager.TriggerEvent("spawn-end");
  }

  public void UpdateAnimatorBool(string name, bool value) {
    if (animator != null) {
      animator.SetBool(name, value);
    } else {
      Debug.LogWarning("UpdateAnimatorBool: No Animator Attached");
    }
  }
}

