using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    private Vector2 velocity;
    private float lifetime;

	public void Initialize(Vector2 velocity, float lifetime) {
        this.velocity = velocity;
        this.lifetime = lifetime;
    }
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(velocity.x * Time.deltaTime, velocity.y * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
        
	}


}
