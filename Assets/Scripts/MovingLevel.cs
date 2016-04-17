using UnityEngine;
using System.Collections;

public class MovingLevel : MonoBehaviour {

    public Vector2 velocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(velocity.x * Time.deltaTime, velocity.y * Time.deltaTime);
	}

    void ChangeSpeed(Vector2 velocity) {
        this.velocity = velocity;
    }
}
