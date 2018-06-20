using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(ThirdPersonBackward))]
[RequireComponent(typeof(ThirdPersonForward))]
[RequireComponent(typeof(ThirdPersonLeft))]
[RequireComponent(typeof(ThirdPersonRight))]
[RequireComponent(typeof(ThirdPersonInteract))]
public class ThirdPersonController : MonoBehaviour
{
  [SerializeField]
  private float movementSpeed = 10f;
  [SerializeField]
  private float rotationSpeed = 20f;
  [SerializeField]
  private Transform holdTransform;

  private Dictionary<Direction, Vector3> directionMap;
  private CharacterController controller;
  private Vector3 leftRotation;
  private Vector3 rightRotation;
  private PlayerState playerState;

  void Start() {
    playerState = GetComponent<PlayerState>();
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

  public void Move (Direction direction) {
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

  public void Interact () {
    IInteractable interactable = playerState.interactables.Find(item => {
      return item != null;
    });

    if (interactable != null) {
      if (playerState.interactables.Contains(interactable)) {
        playerState.interactables.Remove(interactable);
        interactable.Action(gameObject);
      }
    }
  }

  public void Hold () {
    if (holdTransform == null) return;
    if (playerState.heldObject != null) {
      IHoldable holdable = playerState.heldObject.GetComponent<IHoldable>();
      if (holdable != null) holdable.Drop(playerState);
      return;
    }

    IInteractable interactable = playerState.interactables.Find(item => {
      return (item != null) && (item is IHoldable);
    });

    if (interactable != null) {
      playerState.interactables.Remove(interactable);
      IHoldable holdable = (IHoldable)interactable;
      holdable.Hold(gameObject, holdTransform);
    }
  }

  public void Emote() {
    if (playerState.neighbor != null) {
      playerState.animator.SetTrigger("emote");
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

  public void UpdateAnimationState(string name, bool value) {
    playerState.UpdateAnimatorState(name, value);
  }
}

