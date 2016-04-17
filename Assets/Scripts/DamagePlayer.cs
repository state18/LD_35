using UnityEngine;

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
        
        var hm = other.GetComponent<HealthManager>();
        if (hm != null) {
            Debug.Log("Player entered damage zone");
            if (isInstaKill)
                hm.Kill();
            else
                hm.TakeDamage(damageToGive);

            if (destroyOnHit)
                if (GetComponent<EnemyHealthManager>() != null) {
                    GetComponent<EnemyHealthManager>().Kill();
                } else {
                    Destroy(gameObject);
                }
            
        }       
    }
}
