using UnityEngine;
using System.Collections;
using System;

public class Running : MonoBehaviour {
    [SerializeField]
    private float jumpMagnitude;
    [SerializeField]
    LayerMask ground;

    float startingPositionX;

    BoxCollider2D _collider;
    // Use this for initialization
    void Start() {
        startingPositionX = transform.position.x;
        _collider = GetComponent<BoxCollider2D>();
    }

    void Update() {
        // Handle jumping (legal action if grounded)
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            Debug.Log("jumping");
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpMagnitude);
        }

        // Correct horizontal position if needed.
        CorrectHorizontalPosition();

    }

    /// <summary>
    /// Check to see if player is grounded.
    /// </summary>
    /// <returns>Is the player grounded?</returns>
    bool IsGrounded() {
        var distanceToGround = _collider.bounds.extents.y;
        var hitLeft = Physics2D.Raycast(new Vector2(_collider.bounds.min.x + 0.05f, _collider.bounds.center.y), Vector2.down, distanceToGround + 0.1f, ground);
        if (hitLeft)
            return true;

        var hitRight = Physics2D.Raycast(new Vector2(_collider.bounds.max.x - 0.05f, _collider.bounds.center.y), Vector2.down, distanceToGround + 0.1f, ground);
        if (hitRight)
            return true;
        else
            return false;
    }

    void CorrectHorizontalPosition() {
        var xSpeed = 0f;
        var difference = transform.position.x - startingPositionX;
        if (Mathf.Abs(difference) > .1f)
            xSpeed = difference > 0 ? -3f : 3f;

        GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void Attack () {

    }
} 