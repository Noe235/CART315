using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


   
    public void GoToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp() {
        Application.Quit();
        Debug.Log("Quit");
    }
}
