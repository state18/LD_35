using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransport : MonoBehaviour {

    [SerializeField]
    private int destinationIndex;

    void OnTriggerEnter2D(Collider2D other) {
        var hm = other.GetComponent<HealthManager>();

        if (hm != null)
            SceneManager.LoadScene(destinationIndex);
    }
}
