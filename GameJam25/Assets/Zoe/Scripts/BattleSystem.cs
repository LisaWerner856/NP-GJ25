using UnityEngine;
using TMPro;
using System.Collections;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

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
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

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
            EndBatlle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    
    void EndBatlle()
    {
        if (state == BattleState.WON)
        {
            dialogeText.text = " You won the battle!!! ";
        }
        else if (state == BattleState.LOST)
        {
            dialogeText.text = " You were defeated ";
        }
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
            EndBatlle();
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
