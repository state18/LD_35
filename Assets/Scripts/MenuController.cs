using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void OnStartGame() {
        SceneManager.LoadScene(2);
    }

    public void OnInstructions() {
        SceneManager.LoadScene(1);
    }

    public void OnBack() {
        SceneManager.LoadScene(0);
    }

    public void Quit() {
        Application.Quit();
    }
}
