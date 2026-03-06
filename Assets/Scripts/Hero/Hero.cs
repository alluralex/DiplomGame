using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    private Animator animator;

    private int maxHealth = 5;

    private int health;

    public int moneyHero = 5;

    [SerializeField] private InventoryMenu uiController;
    [SerializeField] private UiController menuUI;

    //поднятие ресурсов с пола
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item itemInRange = other.GetComponent<Item>();
            if (itemInRange != null && uiController.HasFreeSlot())
            {

                Debug.Log($"{itemInRange.name} был подобран!");
                uiController.AddToInventoryUI(itemInRange);
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

        GetMoney(4);
    }

    void GetMoney(int moneySpend)
    {
        moneyHero += moneySpend;
        menuUI.updateCountMoney(this);
    }

    public void SpendMoney(int moneyLose)
    {
        moneyHero -= moneyLose;
        menuUI.updateCountMoney(this);
    }

    void OnHealthChange(int damage)
    {
        health = health - damage;
        if (health == 0)
        {
            HeroDie();
        }
    }

    void HeroDie()
    {

    }

    
}
