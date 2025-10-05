using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> inventory = new List<Item>();

    public void AddToInventory(Item item)
    {
        inventory.Add(item);
    }
}
