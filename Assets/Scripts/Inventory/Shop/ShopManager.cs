using Assets.Scripts;
using Assets.Scripts.Inventory;
using Assets.Scripts.Inventory.Bake;
using System;
using UnityEngine;
using static Assets.Scripts.Inventory.Shop.ShopItem;

public class ShopManager : MonoBehaviour
{
    public void TakeResult(Inventory inventory, Slot slot, ItemType typeItem, Hero hero)
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
            //case ItemType.Artefact:
            //    if (slot.item.artefactEffect != null)
            //    {
            //        slot.item.artefactEffect.Apply(hero);
            //        Debug.Log($"Куплен артефакт {slot.item.Name}, эффект применён");
            //    }
            //    else
            //    {
            //        Debug.LogWarning($"Артефакт {slot.item.Name} не имеет эффекта!");
            //    }
            //    break;
            default:
                break;
        }

    }
}
