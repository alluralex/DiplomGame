using Assets.Scripts;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{
    [SerializeField] public UIDocument UIDocument;


    private Label currentMoneyHero;


    private VisualElement inventory;
    private VisualElement craft;
    private VisualElement furnace;
    private VisualElement upgrade;
    private VisualElement shop;
    private VisualElement map;

    private VisualElement gridInventory;
    private VisualElement HotBarSlots;

    private Button tabInventory;
    private Button tabCraft;
    private Button tabFurnace;
    private Button tabUpgrade;
    private Button tabshop;
    private Button tabmap;

    private VisualElement AllInventory;

    private int currentIndex = 0;

    void Awake()
    {

        
        AllInventory = UIDocument.rootVisualElement.Q<VisualElement>("Container");

        inventory = UIDocument.rootVisualElement.Q<VisualElement>("Inventory");
        craft = UIDocument.rootVisualElement.Q<VisualElement>("Craft");
        furnace = UIDocument.rootVisualElement.Q<VisualElement>("Furnace");
        upgrade = UIDocument.rootVisualElement.Q<VisualElement>("Upgrade");
        shop = UIDocument.rootVisualElement.Q<VisualElement>("Shop");
        map = UIDocument.rootVisualElement.Q<VisualElement>("Map");

        gridInventory = UIDocument.rootVisualElement.Q<VisualElement>("GridInventory");
        HotBarSlots = UIDocument.rootVisualElement.Q<VisualElement>("Hotbar");

        tabInventory = UIDocument.rootVisualElement.Q<Button>("TabInventory");
        tabCraft = UIDocument.rootVisualElement.Q<Button>("TabCraft");
        tabFurnace = UIDocument.rootVisualElement.Q<Button>("TabFurnace");
        tabUpgrade = UIDocument.rootVisualElement.Q<Button>("TabUpgrade");
        tabshop = UIDocument.rootVisualElement.Q<Button>("TabShop");
        tabmap = UIDocument.rootVisualElement.Q<Button>("TabMap");

        currentMoneyHero = UIDocument.rootVisualElement.Q<Label>("MoneyCount");

    }

    public void updateCountMoney(Hero heroForMoney)
    {
        currentMoneyHero.text = heroForMoney.moneyHero.ToString();
    }

    public void OpenInventoryMenu(InputAction.CallbackContext button)
    {
        if (button.performed)
        {
            if (AllInventory.style.display == DisplayStyle.Flex)
            {
                AllInventory.style.display = DisplayStyle.None;
                HotBarSlots.style.display = DisplayStyle.Flex;
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                UnityEngine.Cursor.visible = false;
            }
            else
            {
                AllInventory.style.display = DisplayStyle.Flex;
                HotBarSlots.style.display = DisplayStyle.None;
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
        currentIndex = (currentIndex + 1) % 6;
        UpdateUI();
    }

    public void PrevTab()
    {
        currentIndex = (currentIndex + 5) % 6;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //Debug.Log(currentIndex + " нынешний индекс");

        gridInventory.style.display = DisplayStyle.Flex;

        inventory.style.display = DisplayStyle.None;
        craft.style.display = DisplayStyle.None;
        furnace.style.display = DisplayStyle.None;
        shop.style.display = DisplayStyle.None;
        upgrade.style.display = DisplayStyle.None;
        map.style.display = DisplayStyle.None;

        switch (currentIndex)
        {
            case 0: inventory.style.display = DisplayStyle.Flex; break;
            case 1: craft.style.display = DisplayStyle.Flex; break;
            case 2: furnace.style.display = DisplayStyle.Flex; break;
            case 3: upgrade.style.display = DisplayStyle.Flex; break;
            case 4: shop.style.display = DisplayStyle.Flex; break;
            case 5:
                {
                    map.style.display = DisplayStyle.Flex;
                    gridInventory.style.display = DisplayStyle.None; break;
                }
                ;
        }
    }



    public void OnTabNext(InputAction.CallbackContext button)
    {
        if (button.performed)
            PrevTab();
    }

    public void OnTabPrev(InputAction.CallbackContext button)
    {
        if (button.performed)
            NextTab();
    }
}


