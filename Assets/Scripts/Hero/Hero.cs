using Assets.Scripts;
using Assets.Scripts.Inventory;
using Assets.Scripts.Inventory.Upgrade;
using Assets.Scripts.UI.GameEnd;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class Hero : MonoBehaviour
{


    private Animator animator;

    [SerializeField] private int maxHealth = 3;

    private int health;

    public int moneyHero;

    public Inventory inventory;

    public event Action<int> OnMoneyChanged;

    public GridManager GridManager;

    public UpgradeInfo upgradeInfo;

    public List<ArtefactEffect> Artefacts = new List<ArtefactEffect>();
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item itemInRange = other.GetComponent<Item>();
            if (itemInRange == null || itemInRange.isBeingPickedUp) return;

            // Блокируем повторные вызовы
            itemInRange.isBeingPickedUp = true;

            // Отключаем коллайдер (на случай, если флаг не сработает)
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
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        health = maxHealth;

    }

    public void GetMoney(int moneySpend)
    {
        moneyHero += moneySpend;
        StatisticAfterGame.MoneyEarned += moneySpend;
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
