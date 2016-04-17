using UnityEngine;
using System.Collections;
using System;

public class Running : MonoBehaviour {
    [SerializeField]
    private float jumpMagnitude;
    [SerializeField]
    LayerMask ground;
    [SerializeField]
    private float maxCooldown;
    private float cooldown;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    Projectile bullet;
    [SerializeField]
    private float bulletSpeed;

    float startingPositionX;

    BoxCollider2D _collider;
    // Use this for initialization
    void Start() {
        startingPositionX = transform.position.x;
        _collider = GetComponent<BoxCollider2D>();
    }

    void Update() {
        cooldown -= Time.deltaTime;
        // Handle jumping (legal action if grounded)
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            Debug.Log("jumping");
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpMagnitude);
        }

        // Correct horizontal position if needed.
        CorrectHorizontalPosition();

        if (Input.GetButtonDown("Fire1") && cooldown <= 0)
            Fire();

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

    void Fire () {
        cooldown = maxCooldown;

        var projectile = (Projectile)Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.Initialize(new Vector2(bulletSpeed, 0f), 3f);
        cooldown = maxCooldown;
    }
} 