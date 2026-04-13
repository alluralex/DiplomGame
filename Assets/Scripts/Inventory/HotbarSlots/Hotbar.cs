using Assets.Scripts.Inventory;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    [SerializeField] List<Slot> slotsPrefab;
    
    [SerializeField] List<Slot> slotsOfInventory;
    private int activeIndex = 0;                 

    private void Start()
    {
        for (int i = 0; i < slotsOfInventory.Count; i++)
        {
            int index = i;
            slotsOfInventory[i].onItemChanged += () => UpdateHotbarSlot(index);
        }
        UpdateAllHotbarSlots();
        SelectSlot(0); 
    }

    public void SelectSlot(int index)
    {
        activeIndex = index;
        Debug.Log($"Выбран слот хотбара {index} (активный индекс = {activeIndex})");
    }

    public ItemData GetActiveItem()
    {
        if (activeIndex >= 0 && activeIndex < slotsPrefab.Count)
            return slotsPrefab[activeIndex].item;
        return null;
    }
    public void ConsumeActiveItem()
    {
        if (activeIndex >= 0 && activeIndex < slotsOfInventory.Count)
        {
            Slot invSlot = slotsOfInventory[activeIndex];
            if (invSlot.item != null)
            {
                invSlot.item = null;
                invSlot.UpdateVisual();
                invSlot.onItemChanged?.Invoke();
            }
        }
        UpdateHotbarSlot(activeIndex);
    }

    private void UpdateHotbarSlot(int index)
    {
        if (index < slotsPrefab.Count && index < slotsOfInventory.Count)
        {
            slotsPrefab[index].item = slotsOfInventory[index].item;
            slotsPrefab[index].UpdateVisual();
        }
    }

    private void UpdateAllHotbarSlots()
    {
        for (int i = 0; i < slotsPrefab.Count && i < slotsOfInventory.Count; i++)
            UpdateHotbarSlot(i);
    }
}
