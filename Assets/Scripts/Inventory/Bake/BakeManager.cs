using Assets.Scripts.Inventory;
using Assets.Scripts.Inventory.Bake;
using UnityEngine;

public class BakeManager : MonoBehaviour
{
    [SerializeField] private Slot inputSlot;
    [SerializeField] private Slot fuelSlot;
    [SerializeField] private Slot resultSlot;
    [SerializeField] private BakeRecipe[] recipes;

    private void Awake()
    {
        inputSlot.onItemChanged += CheckFurnace;
        fuelSlot.onItemChanged += CheckFurnace;
    }

    private void CheckFurnace()
    {
        ItemData input = inputSlot.item;
        ItemData fuel = fuelSlot.item;

        if (input == null || fuel == null)
        {
            resultSlot.item = null;
            resultSlot.UpdateVisual();
            return;
        }

        foreach (var recipe in recipes)
        {
            if (recipe.input == input && recipe.fuel == fuel)
            {
                resultSlot.item = recipe.result;
                resultSlot.UpdateVisual();
                return;
            }
        }

        resultSlot.item = null;
        resultSlot.UpdateVisual();
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

        inputSlot.item = null;
        fuelSlot.item = null;

        inputSlot.UpdateVisual();
        fuelSlot.UpdateVisual();
        resultSlot.item = null;
        resultSlot.UpdateVisual();

        CheckFurnace();
    }
}
