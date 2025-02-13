using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterFight : MonoBehaviour
{
    public BattleSystem battleSystem;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("wat geraakt");
            Destroy(collision.gameObject);
            
            battleSystem.state = BattleState.START;
            battleSystem.normalCanvas.SetActive(false);
            battleSystem.battleCanvas.SetActive(true);
        }
    }
}