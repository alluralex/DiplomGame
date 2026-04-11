using Assets.Scripts;
using Assets.Scripts.Inventory;
using Assets.Scripts.Inventory.Bake;
using System;
using UnityEngine;
using static Assets.Scripts.Inventory.Shop.ShopItem;

public class ShopManager : MonoBehaviour
{
    public void TakeResult(Inventory inventory, Slot slot, ItemType typeItem)
    {
        switch (typeItem)
        {
            case ItemType.Resource:
                if (!inventory.HaveFreeSlot())
                {
                    Debug.Log("Нет места в инвентаре");
                    return;
                }
                inventory.AddToInventory(slot.item);
                break;
            case ItemType.Artefact:
                Debug.Log("Лол, артефактов ещё нет)))");
                break;
            default:
                break;
        }

    }
}
