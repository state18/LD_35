using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {
    [SerializeField]
    private int damageToGive;
    [SerializeField]
    private bool isInstaKill;
    [SerializeField]
    private bool destroyOnHit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Player entered damage zone");
        var hm = other.GetComponent<HealthManager>();
        if (hm != null) {
            if (isInstaKill)
                hm.Kill();
            else
                hm.TakeDamage(damageToGive);

            if (destroyOnHit)
                Destroy(gameObject);
        }       
    }
}
