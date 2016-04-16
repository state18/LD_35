using UnityEngine;
using System.Collections;

/// <summary>
/// Tracks things such as health and state the player is in (animal form)
/// </summary>
public class HealthManager : MonoBehaviour {

    // TODO UI
    // TODO make player invulernable for a bit after taking damage
    // TODO add enemies of course
    [SerializeField]
    private int Health;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        
    }

    public void TakeDamage(int damage) {
        Debug.Log("Player taking damage.");
        Health -= damage;

        if (Health <= 0)
            Kill();
    }

    public void Kill() {
        Debug.Log("Player killed.");
        GameManager.Instance.OnPlayerDeath();
    }
}
