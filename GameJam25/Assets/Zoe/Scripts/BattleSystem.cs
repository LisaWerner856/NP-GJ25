using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public enum BattleState { INACTIVE, START, PLAYERTURN, ENEMYTURN, WON, LOST, SETUP}
public class BattleSystem : MonoBehaviour
{
    public BuildManager buildManager;
    public RoundManager roundManager;
    public BattleState state;

    public GameObject playerPrefab;
    public GameObject prefab; //TEST
    public GameObject[] prefabs;
    public GameObject battleCanvas;
    public GameObject normalCanvas;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHudScript playerHud;
    public BattleHudScript enemyHud;

    public TMP_Text dialogeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        state = BattleState.INACTIVE;

        normalCanvas.SetActive(true);
        battleCanvas.SetActive(false);
        
    }

    public void Update()
    {
        if (state == BattleState.START)
        {
            StartCoroutine(SetupBattle());
            state = BattleState.SETUP;
        }
    }

    public IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();
        print(playerUnit.name);
        GameObject enemyGo = Instantiate(prefabs[Random.Range(0, prefabs.Length)], enemyBattleStation);
        //GameObject enemyGo = Instantiate(prefab, enemyBattleStation); // TESTING
        Debug.Log($"enemy: {enemyGo}");
        enemyUnit = enemyGo.GetComponent<Unit>();
        
        print(enemyUnit.name);

        dialogeText.text = " A " + enemyUnit.unitName + " aproaches. ";

        playerHud.SetHUD(playerUnit);
        enemyHud.SetHUD(enemyUnit);

        yield return new WaitForSeconds(4f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHud.SetHp(enemyUnit.currentHp);
        dialogeText.text = " The attack was succesful. ";

        yield return new WaitForSeconds(3f);

        if (isDead)
        { 
            state = BattleState.WON;
            StartCoroutine(EndBatlle());
            state = BattleState.INACTIVE;
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
            state = BattleState.INACTIVE;
        }
    }
    
    IEnumerator EndBatlle()
    {
        if (state == BattleState.WON)
        {
            dialogeText.text = " You won the battle!!! ";

            yield return new WaitForSeconds(0f);
            state = BattleState.INACTIVE;
            battleCanvas.SetActive(false);
            normalCanvas.SetActive(true);
            // Drop Loot
            Loot();
            // Remove the player and enemy instances 
            Destroy(enemyUnit.gameObject);
        }
        else if (state == BattleState.LOST)
        {
            dialogeText.text = " You were defeated ";

            yield return new WaitForSeconds(2f);
        }

    }

    public void Loot()
    {
        Debug.Log("Drop loot");
        GameObject lootItem = buildManager.cardLibrary[Random.Range(0, buildManager.cardLibrary.Count - 1)];
        buildManager.cards.Add(lootItem);
    }

    IEnumerator EnemyTurn()
    {
        dialogeText.text = enemyUnit.unitName + " attacks ";

        yield return new WaitForSeconds(2f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHud.SetHp(playerUnit.currentHp);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.LOST;
            StartCoroutine(EndBatlle());
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }
    void PlayerTurn()
    {
        dialogeText.text = "Take an action: attack or heal";
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);

        playerHud.SetHp(playerUnit.currentHp);
        dialogeText.text = " You feel a bit better. ";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerHeal());
    }
}
