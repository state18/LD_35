using UnityEngine;
using System.Collections;
using System;

public class Flying : MonoBehaviour {
    // TODO make the flying area feel kind of like galaga.
    // TODO add shooting to the land area.
    // TODO limit the player's movement to the bottom section of the flying screen
    [SerializeField]
    private float verticalSpeed;
    [SerializeField]
    private float horizontalSpeed;

    [SerializeField]
    Projectile bullet;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float maxCooldown;
    private float cooldown;

    void Update() {
        if (cooldown > 0)
            cooldown -= Time.deltaTime;

        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector3(horizontalInput * horizontalSpeed, verticalInput * verticalSpeed);

        if (Input.GetButton("Fire1") && cooldown <= 0)
            Fire();
    }

    void Fire() {
        cooldown = maxCooldown;

        var projectile = (Projectile)Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.Initialize(new Vector2(0f,bulletSpeed), 3f);
        cooldown = maxCooldown;
    }
}
