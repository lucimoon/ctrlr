using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonController : MonoBehaviour
{
  [SerializeField]
  private float movementSpeed = 10f;
  [SerializeField]
  private float rotationSpeed = 20f;
  [SerializeField]
  private Transform holdTransform;
  
  [SerializeField]
  private Animator animator;

  private Dictionary<Direction, Vector3> directionMap;
  private CharacterController controller;
  private Vector3 leftRotation;
  private Vector3 rightRotation;

  void Start() {
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

      // TODO: make this a switch
      if (direction == Direction.forward) {
        controller.SimpleMove(Vector3.forward * movementSpeed);
        // gameObject.transform = Quaternion.LookRotation(Vector3.forward, Vector3.up);
      }

      if (direction == Direction.backward) {
        controller.SimpleMove(Vector3.back * movementSpeed);
      }

      if (direction == Direction.left) {
        controller.SimpleMove(Vector3.left * movementSpeed);
      }
      
      if (direction == Direction.right) {
        controller.SimpleMove(Vector3.right * movementSpeed);
      }
    }
  }

  public void Interact () {
  }

  public void Hold () {
  }

  public void Emote() {
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
    if (animator != null) {
      animator.SetBool(name, value);
    }
  }
}

