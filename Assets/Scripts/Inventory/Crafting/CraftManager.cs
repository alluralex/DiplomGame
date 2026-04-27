using Assets.Scripts.Inventory;
using Assets.Scripts.UI.GameEnd;
using System.Linq;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    [SerializeField] private Transform panelSlots;
    [SerializeField] private Slot resultSlot;
    [SerializeField] private Inventory inventoryCraft;

    private Slot[] craftSlots;
    public CraftRecipe[] recipes;

    private void Awake()
    {
        craftSlots = panelSlots.GetComponentsInChildren<Slot>();
        if (craftSlots.Length != 9)
            Debug.LogError($"Ожидается 9 слотов, найдено {craftSlots.Length}");

        foreach (var slot in craftSlots)
            slot.onItemChanged += CheckCraft;
    }

    public void CheckCraft()
    {
        ItemData[] current = craftSlots.Select(s => s.item).ToArray();
        if (current.Length != 9) return;

        foreach (var recipe in recipes)
        {
            if (recipe.pattern == null || recipe.pattern.Length != 9) continue;
            if (Match(recipe.pattern, current))
            {
                resultSlot.item = recipe.result;
                UpdateResult();
                return;
            }
        }

        resultSlot.item = null;
        resultSlot.UpdateVisual();
        UpdateResult();
    }

    bool Match(ItemData[] a, ItemData[] b)
    {
        if (a == null || b == null) return false;
        if (a.Length != 9 || b.Length != 9) return false;

        for (int i = 0; i < 9; i++)
        {
            if (a[i] == null && b[i] == null) continue;
            if (a[i] == null || b[i] == null) return false;
            if (a[i].ItemId != b[i].ItemId) return false;
        }
        return true;
    }

    public void UpdateResult()
    {
        inventoryCraft.PrefabGet(resultSlot);
    }

    public void TakeResult(Inventory playerInventory)
    {
        if (resultSlot.item == null)
        {
            Debug.Log("Нечего забирать");
            return;
        }

        if (!playerInventory.HaveFreeSlot())
        {
            Debug.Log("Нет места в инвентаре");
            return;
        }

        playerInventory.AddToInventory(resultSlot.item);
        StatisticAfterGame.CraftsComplete++;

        foreach (var slot in craftSlots)
        {
            slot.item = null;
            slot.UpdateVisual();
            slot.onItemChanged?.Invoke();
        }

        resultSlot.item = null;
        resultSlot.UpdateVisual();

        CheckCraft();
    }
}