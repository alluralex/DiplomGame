using Assets.Scripts;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private UIDocument UIDocument;

    private VisualElement inventory;
    private VisualElement craft;
    private VisualElement furnace;
    private VisualElement upgrade;
    private VisualElement shop;

    private Button tabInventory;
    private Button tabCraft;
    private Button tabFurnace;
    private Button tabUpgrade;
    private Button tabshop;

    private VisualElement AllInventory;
    
    private int currentIndex = 0;

    void Awake()
    {
        AllInventory = UIDocument.rootVisualElement.Q<VisualElement>("Container");

        inventory = UIDocument.rootVisualElement.Q<VisualElement>("Inventory");
        craft = UIDocument.rootVisualElement.Q<VisualElement>("Craft");
        furnace = UIDocument.rootVisualElement.Q<VisualElement>("Furnace");
        //upgrade = root.Q<VisualElement>("Upgrade");
        //shop = root.Q<VisualElement>("Shop");

        tabInventory = UIDocument.rootVisualElement.Q<Button>("TabInventory");
        tabCraft = UIDocument.rootVisualElement.Q<Button>("TabCraft");
        tabFurnace = UIDocument.rootVisualElement.Q<Button>("TabFurnace");
        //tabUpgrade = root.Q<Button>("TabUpgrade");
        //tabshop = root.Q<Button>("TabShop");
    }

    public void OpenInventoryMenu(InputAction.CallbackContext button)
    {
        if (button.performed)
        {
            if (AllInventory.style.display == DisplayStyle.Flex)
            {
                AllInventory.style.display = DisplayStyle.None;
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                UnityEngine.Cursor.visible = false;
            }
            else
            {
                AllInventory.style.display = DisplayStyle.Flex;
                UnityEngine.Cursor.lockState = CursorLockMode.Confined;
                UnityEngine.Cursor.visible = true;
            }
        }
    }

    public void SetTab(int index)
    {
        currentIndex = index;
        UpdateUI();
    }

    public void NextTab()
    {
        currentIndex = (currentIndex + 1) % 3;
        UpdateUI();
    }

    public void PrevTab()
    {
        currentIndex = (currentIndex + 2) % 3;
        UpdateUI();
    }

    private void UpdateUI()
    {
        inventory.style.display = DisplayStyle.None;
        craft.style.display = DisplayStyle.None;
        furnace.style.display = DisplayStyle.None;
        //upgrade.style.display = DisplayStyle.None;
        //shop.style.display = DisplayStyle.None;

        switch (currentIndex)
        {
            case 0: inventory.style.display = DisplayStyle.Flex; break;
            case 1: craft.style.display = DisplayStyle.Flex; break;
            case 2: furnace.style.display = DisplayStyle.Flex; break;
            //case 3: upgrade.style.display = DisplayStyle.Flex; break;
            //case 4: shop.style.display = DisplayStyle.Flex; break;
        }
    }

    public void OnTabNext(InputAction.CallbackContext button)
    {
        if (button.performed)
            NextTab();
    }

    public void OnTabPrev(InputAction.CallbackContext button)
    {
        if (button.performed)
            PrevTab();
    }
}

