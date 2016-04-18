using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Handle important events such as Player death/respawning
/// </summary>
public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    // Use this for initialization
    void Start() {
        Instance = this;
        if (SceneManager.GetActiveScene().buildIndex == 2)
            BossEnemy.spawnsRemaining = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            SceneManager.LoadScene(0);
        }
    }
    public void OnPlayerDeath() {
        StartCoroutine("OnPlayerDeathCo");
    }

    IEnumerator OnPlayerDeathCo() {
        GetComponent<AudioSource>().Play();
        Destroy(FindObjectOfType<HealthManager>().gameObject);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BossDefeated() {
        StartCoroutine("BossDefeatedCo");
        
    }

    IEnumerator BossDefeatedCo() {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(5);
    }
}
