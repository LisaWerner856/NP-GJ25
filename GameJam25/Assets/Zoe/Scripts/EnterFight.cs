using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterFight : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("wat geraakt");
            Destroy(collision.gameObject);
            SceneManager.LoadScene(sceneName: "CombatSystem");//, LoadSceneMode.Additive);
        }
    }
}