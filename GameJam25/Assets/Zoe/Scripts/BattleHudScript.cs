using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHudScript : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text levelText;
    public Slider hpSlider;


    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = " LVL: " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHp;
        hpSlider.value = unit.currentHp;
    }

    public void SetHp(int hp)
    {
        hpSlider.value = hp;
    }
}
