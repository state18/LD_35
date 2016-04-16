using UnityEngine;
using System.Collections;

public class FireAtPlayer : MonoBehaviour {
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private Projectile bullet;
    [SerializeField]
    private float bulletLifetime;
    [SerializeField]
    private float playerDetectionRadius;
    private Transform playerTransform;

    [SerializeField]
    private float maxCooldown;
    private float cooldown;
    [SerializeField]
    private float shotMagnitude;
    [SerializeField]
    LayerMask playerMask;

	// Use this for initialization
	void Start () {
        playerTransform = FindObjectOfType<HealthManager>().gameObject.transform;
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

        var difference = playerTransform.position - transform.position;
        difference = difference.normalized * shotMagnitude;
        var projectile = (Projectile)Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.Initialize(difference, bulletLifetime);
    }
}
