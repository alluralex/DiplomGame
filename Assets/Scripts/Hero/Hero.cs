using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Animator animator;

    private Inventory inventory = new();

    private int maxHealth = 5;

    private int health;

    //поднятие ресурсов с пола
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item itemInRange = other.GetComponent<Item>();
            if (itemInRange != null)
            {
                inventory.AddToInventory(itemInRange);
                Debug.Log($"{itemInRange.name} был подобран!");
                Destroy(itemInRange.gameObject);
            }
        }
    }
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        health = maxHealth;
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
