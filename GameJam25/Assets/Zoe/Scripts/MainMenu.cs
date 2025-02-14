using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartPress()
    {
        SceneManager.LoadScene(sceneName: "LoopScene");
    }

    public void OnQuitPress()
    {
        Application.Quit();
    }
}
