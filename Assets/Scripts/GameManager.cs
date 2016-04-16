using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Handle important events such as Player death/respawning
/// </summary>
public class GameManager : MonoBehaviour {
    public static GameManager Instance;

	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPlayerDeath () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
