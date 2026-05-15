using Assets.Scripts;
using Assets.Scripts.Inventory;
using Assets.Scripts.Inventory.Upgrade;
using Assets.Scripts.PlayerSettings;
using Assets.Scripts.UI.GameEnd;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    public int moneyHero;

    public Inventory inventory;

    public event Action<int> OnMoneyChanged;

    public GridManager GridManager;

    public UpgradeInfo upgradeInfo;

    public List<ArtefactEffect> Artefacts = new List<ArtefactEffect>();

    public event Action OnUpgradeInfoChanged;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item itemInRange = other.GetComponent<Item>();
            if (itemInRange == null || itemInRange.isBeingPickedUp) return;

            itemInRange.isBeingPickedUp = true;

            other.enabled = false;

            if (inventory.HaveFreeSlot())
            {
                Debug.Log($"{itemInRange.name} был подобран!");
                inventory.AddToInventory(itemInRange.itemData);

                if (IsDoubleResource(upgradeInfo.ResourceMultiplayer))
                {
                    Debug.Log($"Удвоение сработало! Шанс: {upgradeInfo.ResourceMultiplayer}%, предмет: {itemInRange.name}");
                    if (inventory.HaveFreeSlot())
                        inventory.AddToInventory(itemInRange.itemData);
                    else
                        Debug.Log("Нет места для дубликата");
                }

                Destroy(itemInRange.gameObject);
            }
            else
            {
                Debug.Log("Инвентарь полный :(((");
                itemInRange.isBeingPickedUp = false;
                other.enabled = true;
            }
        }
    }

    public void InvokeUpgradeInfoChanged()
    {
        OnUpgradeInfoChanged?.Invoke();
    }
    void Start()
    {
        Settings.Load();
        Statistic.Load();

    }

    public void GetMoney(int moneySpend)
    {
        moneyHero += moneySpend;
        StatisticAfterGame.MoneyEarned += moneySpend;
        Statistic.MoneyEarned += moneySpend;
        Statistic.Save();
        OnMoneyChanged(moneyHero);
    }

    public void SpendMoney(int moneyLose)
    {
        moneyHero -= moneyLose;
        OnMoneyChanged(moneyHero);
    }

    public float GetDamageMultiplayer()
    {
        float multiplayer = upgradeInfo.damageMultiplayer;
        return multiplayer;
    }

    public bool IsDoubleResource(int chance)
    {
        int random = UnityEngine.Random.Range(0, 101);
        if (random <= chance)
        {
            return true;
        }
        return false;
    }
}
