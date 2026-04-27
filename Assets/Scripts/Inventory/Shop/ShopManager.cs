using Assets.Scripts;
using Assets.Scripts.Inventory;
using Assets.Scripts.Inventory.Bake;
using Assets.Scripts.Inventory.Shop;
using Assets.Scripts.UI.GameEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<Slot> slotsOfArtefacts;

    [SerializeField] private List<ItemData> allArtefacts;
    public void RefreshShop()
    {
        // Копируем список всех артефактов
        var available = new List<ItemData>(allArtefacts);
        // Перемешиваем
        for (int i = 0; i < available.Count; i++)
        {
            int rand = UnityEngine.Random.Range(i, available.Count);
            (available[i], available[rand]) = (available[rand], available[i]);
        }

        // Раскладываем в слоты
        for (int i = 0; i < slotsOfArtefacts.Count; i++)
        {
            Slot slot = slotsOfArtefacts[i];
            slot.item = i < available.Count ? available[i] : null;
            slot.UpdateVisual(); // обновляем иконку

            // Обновляем отображение цены в ShopItem (если есть)
            ShopItem shopItem = slot.GetComponent<ShopItem>();
            if (shopItem != null)
                shopItem.UpdateDisplay();
        }
    }

    private void Start()
    {
        RefreshShop();
    }

    private void OnEnable()
    {
        RefreshShop();
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
                    RefreshShop(); 
                }
                else
                {
                    Debug.LogWarning($"Артефакт {slot.item.Name} не имеет эффекта!");
                }
                break;
        }
    }
}
