using Assets.Scripts;
using Assets.Scripts.Inventory;
using Assets.Scripts.Inventory.Bake;
using Assets.Scripts.Inventory.Shop;
using Assets.Scripts.PlayerSettings;
using Assets.Scripts.UI.GameEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<Slot> slotsOfArtefacts;

    [SerializeField] private List<ItemData> allArtefacts;
    private Hero heroThis;

    public void RefreshShop()
    {
        var available = new List<ItemData>(allArtefacts);
        for (int i = 0; i < available.Count; i++)
        {
            int rand = UnityEngine.Random.Range(i, available.Count);
            (available[i], available[rand]) = (available[rand], available[i]);
        }

        for (int i = 0; i < slotsOfArtefacts.Count; i++)
        {
            Slot slot = slotsOfArtefacts[i];
            slot.item = i < available.Count ? available[i] : null;
            slot.UpdateVisual();

            ShopItem shopItem = slot.GetComponent<ShopItem>();
            if (shopItem != null)
                shopItem.UpdateDisplay();
        }
    }

    private void Start()
    {
        RefreshShop();
        Hero hero = FindFirstObjectByType<Hero>();
        heroThis = hero;
    }

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
            case ItemType.Artefact:
                if (slot.item.artefactEffect != null)
                {
                    slot.item.artefactEffect.Apply(hero);
                    Debug.Log($"Куплен артефакт {slot.item.Name}, эффект применён");
                    StatisticAfterGame.ArtefactsBuy++;
                    Statistic.ArtefactsBuy++;
                    Statistic.Save();
                    hero.InvokeUpgradeInfoChanged();
                    RefreshShop();
                }
                else
                {
                    Debug.LogWarning($"Артефакт {slot.item.Name} не имеет эффекта!");
                }
                break;

        }
    }
    public void TakeAdminItem(Inventory inventory, Inventory GoToInventory, Slot slot, ItemType typeItem, Hero hero)
    {
        switch (typeItem)
        {
            case ItemType.Resource:
                if (!GoToInventory.HaveFreeSlot())
                {
                    Debug.Log("Нет места в инвентаре");
                    return;
                }
                GoToInventory.AddToInventory(slot.item);
                break;
            case ItemType.Artefact:
                if (slot.item.artefactEffect != null)
                {
                    slot.item.artefactEffect.Apply(hero);
                    hero.InvokeUpgradeInfoChanged();
                }
                break;
            case ItemType.Tower:
                if (!GoToInventory.HaveFreeSlot())
                {
                    Debug.Log("Нет места в инвентаре");
                    return;
                }
                GoToInventory.AddToInventory(slot.item);
                break;
        }
    }
}
