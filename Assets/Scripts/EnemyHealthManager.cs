using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

    public int Health;
    [SerializeField]
    private AudioSource destroyedEffect;

    public void TakeDamage(int damage) {
        Health -= damage;
        

        if (Health <= 0)
            Kill();
    }

    public void Kill() {
        if (tag == "boss")
            GetComponent<BossEnemy>().Spawn();
        if (destroyedEffect != null)
            Instantiate(destroyedEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
