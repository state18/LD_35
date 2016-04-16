using UnityEngine;
using System.Collections;
using System;

public class Swimming : MonoBehaviour {
    [SerializeField]
    private float jumpMagnitude;
    [SerializeField]
    private float horizontalMagnitude;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private Projectile bullet;
    [SerializeField]
    private float projectileVelocity;
    [SerializeField]
    private float maxCooldown;

    private float cooldownTimer;

    void Update () {
        cooldownTimer -= Time.deltaTime;

        var horizontalDirection = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalDirection * horizontalMagnitude, GetComponent<Rigidbody2D>().velocity.y);

        if (horizontalDirection != 0 && Mathf.Sign(horizontalDirection) != Mathf.Sign(transform.localScale.x)) 
            Flip();
        

        if (Input.GetButtonDown("Jump")) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpMagnitude);
        }

        // Handle shooting
        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0) 
            Fire();
        
    }

    void Fire() {
        var projectile = (Projectile)Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.Initialize(new Vector2(projectileVelocity* Mathf.Sign(transform.localScale.x), 0f), 3f);
        cooldownTimer = maxCooldown;
    }

    void Flip() {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
    }
}
