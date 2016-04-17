using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tracks things such as health and state the player is in (animal form)
/// </summary>
public class HealthManager : MonoBehaviour {

    // TODO UI
    // TODO make player invulernable for a bit after taking damage
    // TODO add enemies of course
    [SerializeField]
    private int Health;
    [SerializeField]
    private Toggle[] life;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        
    }

    public void TakeDamage(int damage) {
        Debug.Log("Player taking damage.");
        var length = Mathf.Max(0, Health - damage);
        for (int i = Health; i > length; i--) {
            life[i - 1].isOn = false;
        }
        Health -= damage;

        if (Health <= 0)
            Kill();
    }

    public void Kill() {
        for (int i = Health; i > 0; i--) {
            life[i - 1].isOn = false;
        }
        Debug.Log("Player killed.");
        GameManager.Instance.OnPlayerDeath();
    }
}
