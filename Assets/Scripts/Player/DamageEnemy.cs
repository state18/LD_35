using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {
    [SerializeField]
    private int damageToGive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        var hm = other.GetComponent<EnemyHealthManager>();

        if (hm != null) {
            hm.TakeDamage(damageToGive);
            Destroy(gameObject);
        }
    }
}
