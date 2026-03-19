using Assets.Scripts;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private UIDocument UIDocument;
    [SerializeField] private Hero hero;

    private Item[] inventory = new Item[16];

    List<VisualElement> hotbarsSlot;

    List<VisualElement> v;

    VisualElement RaisedObject; // клетка, откуда подняли
    VisualElement DroppedObject; // клетка, куда попустили

    VisualElement NoObject; // Промежуточный этап для сохранения


    StyleBackground item;

    void Start()
    {
        VisualElement Grid = UIDocument.rootVisualElement.Query<VisualElement>("GridInventory");

        VisualElement HotbarGrid = UIDocument.rootVisualElement.Query<VisualElement>("Hotbar");


        UIDocument.rootVisualElement.RegisterCallback<PointerUpEvent>(OnGlobalPointerUp);

        hotbarsSlot = new List<VisualElement>(HotbarGrid.Children());
        v = new List<VisualElement>(Grid.Children());

        foreach (var slot in v)
        {
            slot.RegisterCallback<PointerDownEvent>(OnPointerDown);
            slot.RegisterCallback<PointerUpEvent>(OnPointerUp);
        }
    }
    public void AddToInventoryUI(Item getItem)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null && v[i].style.backgroundImage.value == null)
            {
                inventory[i] = getItem;

                v[i].style.backgroundImage = inventory[i].Image;

                UpdateHotbar();
                break;
            }
        }
    }

    public bool HasFreeSlot()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
                return true;
        }

        return false;
    }

    private void OnPointerDown(PointerDownEvent evt)
    {
        RaisedObject = (VisualElement)evt.currentTarget;

        if (RaisedObject.name == "SlotIcon")
        {
            Debug.Log($"Ты поднял объект {RaisedObject.style.backgroundImage}");

            item = RaisedObject.style.backgroundImage;

            RaisedObject.style.backgroundImage = null;

            UpdateHotbar();
        }
        else
        {
            Debug.Log($"Ты пытаешься поднять совсем не предмет: {RaisedObject.name}");
        }
    }

    private void OnPointerUp(PointerUpEvent evt)
    {
        if (item == null)
            return;

        VisualElement target = (VisualElement)evt.currentTarget;

        if (target.name == "SlotIcon")
        {
            StyleBackground temp = target.style.backgroundImage;

            target.style.backgroundImage = item;
            RaisedObject.style.backgroundImage = temp;
            item = null;
            UpdateHotbar();
        }
    }
    private void OnGlobalPointerUp(PointerUpEvent evt)
    {
        if (item == null)
            return;

        VisualElement target = evt.target as VisualElement;

        if (target == null || target.name != "SlotIcon")
        {
            if (RaisedObject != null)
            {
                RaisedObject.style.backgroundImage = item;
            }
        }

        item = null;
    }
    void UpdateHotbar()
    {
        for (int i = 0; i < 4; i++)
        {
            int inventoryIndex = 12 + i;

            if (inventory[inventoryIndex] != null) 
            { 
                hotbarsSlot[i].style.backgroundImage = new StyleBackground(inventory[inventoryIndex].Image); 
            } 
            else 
            { 
                hotbarsSlot[i].style.backgroundImage = null; 
            }
        }
    }
}
