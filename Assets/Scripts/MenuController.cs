using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void OnStartGame() {
        SceneManager.LoadScene(0);
    }

    public void OnInstructions() {
        SceneManager.LoadScene(4);
    }

    public void OnBack() {
        SceneManager.LoadScene(3);
    }

    public void Quit() {
        Application.Quit();
    }
}
