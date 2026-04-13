using Assets.Scripts;
using Assets.Scripts.Inventory;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item itemInRange = other.GetComponent<Item>();
            if (itemInRange != null && inventory.HaveFreeSlot())
            {
                Debug.Log($"{itemInRange.name} был подобран!");
                inventory.AddToInventory(itemInRange.itemData);
                Destroy(itemInRange.gameObject);
            }
            else
            {
                Debug.Log("Инвентарь полный :(((");
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
        OnMoneyChanged(moneyHero);
    }

    public void SpendMoney(int moneyLose)
    {
        moneyHero -= moneyLose;
        OnMoneyChanged(moneyHero);
    }  
}
