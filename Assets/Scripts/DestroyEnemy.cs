using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

    public enum Direction { Up, Down, Left, Right, None }
    [SerializeField]
    private Direction direction;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<EnemyHealthManager>() != null)

            if (direction == Direction.None
                || direction == Direction.Left && other.GetComponentInParent<MovingLevel>().velocity.x > 0
                || direction == Direction.Right && other.GetComponentInParent<MovingLevel>().velocity.x < 0
                || direction == Direction.Up && other.GetComponentInParent<MovingLevel>().velocity.y < 0
                || direction == Direction.Down && other.GetComponentInParent<MovingLevel>().velocity.y > 0)

                Destroy(other.gameObject);
    }
}
