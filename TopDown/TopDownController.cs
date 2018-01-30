using UnityEngine;
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
		private float speed = 5f;

    [SerializeField]
		private bool keepWithinBounds = false;

		private Dictionary<Direction, Vector3> directionMap = new Dictionary<Direction, Vector3>
		{
			{Direction.up, Vector3.up},
			{Direction.down, Vector3.down},
			{Direction.left, Vector3.left},
			{Direction.right, Vector3.right},
		};

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
	}
}
