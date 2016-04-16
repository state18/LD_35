using UnityEngine;
using System.Collections;

public class MovingLevel : MonoBehaviour {

    [SerializeField]
    private float Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(Speed * Time.deltaTime, 0f);
	}

    void ChangeSpeed(float speed) {
        Speed = speed;
    }
}
