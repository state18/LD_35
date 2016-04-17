using UnityEngine;
using System.Collections;

/// <summary>
/// For usage with Air Enemies
/// </summary>
public class FireFromSides : MonoBehaviour {
    [SerializeField]
    Transform firePointLeft;
    [SerializeField]
    Transform firePointRight;
    [SerializeField]
    private Projectile bullet;
    [SerializeField]
    private float bulletLifetime;
    [SerializeField]
    private float playerDetectionRadius;

    [SerializeField]
    private float maxCooldown;
    private float cooldown;
    [SerializeField]
    private float shotMagnitude;
    [SerializeField]
    LayerMask playerMask;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0) {
            if (Physics2D.OverlapCircle(transform.position, playerDetectionRadius, playerMask)) {
                Fire();
            }

        }
    }

    void Fire() {
        cooldown = maxCooldown;

        //left shot
        var projectile = (Projectile)Instantiate(bullet, firePointLeft.position, firePointLeft.rotation);
        projectile.Initialize(new Vector2(-shotMagnitude,-shotMagnitude), bulletLifetime);

        //right shot
        projectile = (Projectile)Instantiate(bullet, firePointRight.position, firePointRight.rotation);
        projectile.Initialize(new Vector2(shotMagnitude, -shotMagnitude), bulletLifetime);
    }
}
