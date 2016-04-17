using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tracks things such as health and state the player is in (animal form)
/// </summary>
public class HealthManager : MonoBehaviour {

    // TODO make player invulernable for a bit after taking damage
    [SerializeField]
    private int Health;
    [SerializeField]
    private float invulernabilityTime;
    private float invulnTimeLeft;
    [SerializeField]
    private Toggle[] life;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (invulnTimeLeft > 0)
            invulnTimeLeft -= Time.deltaTime;

    }

    public void TakeDamage(int damage) {
        if (invulnTimeLeft <= 0) {
            invulnTimeLeft = invulernabilityTime;
            InvokeRepeating("FlickerSprite", 0f, .1f);
            Debug.Log("Player taking damage.");
            var length = Mathf.Max(0, Health - damage);
            for (int i = Health; i > length; i--) {
                life[i - 1].isOn = false;
            }
            Health -= damage;
            GetComponent<AudioSource>().Play();
            if (Health <= 0)
                Kill();
        }
    }

    public void Kill() {
        CancelInvoke("FlickerSprite");
        GetComponent<SpriteRenderer>().enabled = false;

        for (int i = Health; i > 0; i--) {
            life[i - 1].isOn = false;
        }
        Debug.Log("Player killed.");
        GameManager.Instance.OnPlayerDeath();
    }

    void FlickerSprite() {
        var sr = GetComponent<SpriteRenderer>();
        sr.enabled = !sr.enabled;
    }

    void LateUpdate() {
        if (invulnTimeLeft <= 0) {
            CancelInvoke("FlickerSprite");
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
