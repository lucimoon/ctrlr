using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ThirdPersonFixedLeft))]
[RequireComponent(typeof(ThirdPersonFixedRight))]
public class ThirdPersonFixedController : ThirdPersonController
{
  [SerializeField]
  protected KeyCode forward = KeyCode.None;
  [SerializeField]
  protected KeyCode backward = KeyCode.None;
  [SerializeField]
  protected KeyCode left = KeyCode.None;
  [SerializeField]
  protected KeyCode right = KeyCode.None;

  Vector3 relativePos = new Vector3(0f, 0f, 10f);
  Dictionary<Direction, bool> directionBools;

  protected override void Start() {
    base.Start();
    directionMap = new Dictionary<Direction, Vector3>
    {
      {Direction.forward, new Vector3(0f, 0f, 10f)},
      {Direction.backward, new Vector3(0f, 0f, -10f)},
      {Direction.left, new Vector3(-5f, 0f, 0f)},
      {Direction.right, new Vector3(5f, 0f, 0f)},
    };

    directionBools = new Dictionary<Direction, bool>
    {
      {Direction.forward, true},
      {Direction.backward, false},
      {Direction.left, false},
      {Direction.right, false},
    };
  }

  void Update() {
    if (Input.GetKey(left) || Input.GetKey(right) || Input.GetKey(forward) || Input.GetKey(backward)) {
      Vector3 newPosition = gameObject.transform.position;

      if (Input.GetKey(left)) {
        newPosition.x -= 10f;
      }
      if (Input.GetKey(right)) {
        newPosition.x += 10f;
      }
      if (Input.GetKey(forward)) {
        newPosition.z += 10f;
      }
      if (Input.GetKey(backward)) {
        newPosition.z -= 10f;
      }

      relativePos = newPosition - gameObject.transform.position;
    }
  }

  void FixedUpdate() {
    gameObject.transform.rotation = Quaternion.Lerp (gameObject.transform.rotation, Quaternion.LookRotation(relativePos, Vector3.up), rotationSpeed * Time.deltaTime);
  }

  public override void Move (Direction direction) {
    if (directionMap.ContainsKey(direction)) {
      Vector3 vector = directionMap[direction] * Time.deltaTime;
      controller.SimpleMove(vector * movementSpeed);
    }
  }

  public override void Interact () {
  }

  public override void Hold () {
  }

  public override void Emote() {
  }
}

