using UnityEngine;
using System.Collections.Generic;

namespace tardigrage_alpha.Assets.Scripts.Ctrlr
{
  [RequireComponent(typeof(TDDown))]
  [RequireComponent(typeof(TDUp))]
  [RequireComponent(typeof(TDLeft))]
  [RequireComponent(typeof(TDRight))]
	public class TopDownController : MonoBehaviour
	{
		[SerializeField]
		private float speed = 5f;
		private Dictionary<Direction, Vector3> directionMap = new Dictionary<Direction, Vector3>
		{
			{Direction.up, Vector3.up},
			{Direction.down, Vector3.down},
			{Direction.left, Vector3.left},
			{Direction.right, Vector3.right},
		};

		public void Move (Direction direction) {
			if (directionMap.ContainsKey(direction)) {
				Vector3 vector = directionMap[direction] * speed * Time.deltaTime;
				transform.Translate(vector, Space.World);
			}
		}
	}
}
