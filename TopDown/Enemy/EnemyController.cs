using UnityEngine;
using System.Collections;

namespace tardigrage_alpha.Assets.Scripts.Ctrlr.TopDown.Enemy
{
    public class EnemyController : TopDownController
    {
      public Vector2 Velocity = new Vector2(1, 0);

      [Range(0, 5)]
      public float RotateSpeed = .5f;
      [Range(0, 5)]
      public float Radius = 1f;

      private float angle;

      private void Start()
      {
        CircleCenterY(0, Direction.right);
      }

      private void CircleCenterY(float initialAngle, Direction direction) {
        // Get screen midpoint Y in world Coords
        if (mainCamera != null) Debug.LogWarning("Attach camera to EnemyController");
        Vector3 centerY = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f));

        Vector2 center = new Vector3(transform.position.x, centerY.y, transform.position.z);
        float radius = transform.position.y - centerY.y;

        StartCoroutine(Circle(center, radius, initialAngle, direction));
      }

      private IEnumerator Circle(Vector2 center, float radius, float initialAngle, Direction direction)
      {
          float angle = initialAngle;
          float fullCircle = Mathf.Abs(Mathf.PI * 2);

          while (angle <= fullCircle)
          {
            if (direction == Direction.left) {
              angle -= RotateSpeed * Time.deltaTime;
            } else {
              angle += RotateSpeed * Time.deltaTime;
            }

            var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;

            transform.position = center + offset;
            yield return null;
          }
      }
    }
}