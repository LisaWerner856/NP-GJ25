using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHp;
    public int currentHp;

    public int healBuff = 0; // Uncomment me to enable water healing card

    private void Start()
    {
        currentHp = maxHp;
    }

    public bool TakeDamage(int dmg)
    {
        currentHp -= dmg;

        if (currentHp <= 0)
            return true;
        else 
            return false;
    }

    public void Heal(int amount)
    {
        currentHp += amount;
        currentHp += (amount + healBuff); // Uncomment me to enable water healing card 
        if (currentHp > maxHp)
            currentHp = maxHp;
    }
}
