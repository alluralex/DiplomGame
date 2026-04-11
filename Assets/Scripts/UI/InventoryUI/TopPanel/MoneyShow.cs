using TMPro;
using UnityEngine;

public class MoneyShow : MonoBehaviour
{
    [SerializeField] private Hero Hero;
    [SerializeField] private TextMeshProUGUI CurrentMoney;

    private void Start()
    {
        Hero.OnMoneyChanged += UpdateMoneyText;
        UpdateMoneyText(Hero.moneyHero);
    }

    private void UpdateMoneyText(int GetMoney)
    {
        CurrentMoney.text = GetMoney.ToString();
    }
}
