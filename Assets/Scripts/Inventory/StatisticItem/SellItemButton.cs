using Assets.Scripts.Inventory;
using UnityEngine;

public class SellItemButton : MonoBehaviour
{
    [SerializeField] private StatisticItem statisticItem;
    [SerializeField] private Hero HeroMoney;
    
    public void OnClick()
    {
        if (statisticItem == null)
        {
            Debug.LogError("StatisticItem не назначен");
            return;
        }
        statisticItem.SellItem(HeroMoney);

    }
}
