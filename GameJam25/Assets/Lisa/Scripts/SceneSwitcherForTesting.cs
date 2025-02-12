using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherForTesting : MonoBehaviour
{
    public int gameScene;
    public int fightScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FightScene()
    {
        SceneManager.LoadScene(fightScene);
    }

    public void GameScene()
    {
        SceneManager.LoadScene(gameScene);
    }
}
