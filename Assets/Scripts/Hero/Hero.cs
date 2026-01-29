using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Animator animator;

    private int maxHealth = 5;

    private int health;

    [SerializeField] private UiController uiController;

    //поднятие ресурсов с пола
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item itemInRange = other.GetComponent<Item>();
            if (itemInRange != null && uiController.FullInventory())
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
