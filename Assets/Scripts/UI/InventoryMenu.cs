using Assets.Scripts;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private UIDocument UIDocument;
    [SerializeField] private Hero hero;

    private Item[] inventory = new Item[16];

    List<VisualElement> v;

    void Start()
    {
        VisualElement Grid = UIDocument.rootVisualElement.Query<VisualElement>("GridInventory");

        v = new List<VisualElement>(Grid.Children());
    }
    public void AddToInventoryUI(Item getItem)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null && v[i].style.backgroundImage.value == null)
            {
                inventory[i] = getItem;

                v[i].style.backgroundImage = inventory[i].Image;

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

    private void PointerUpEvent(PointerUpEvent pointerUp)
    {
        Debug.Log($"Ты схватил предмет! {pointerUp}");
    }

    private void OnPointerDown(PointerDownEvent pointerDown)
    {
        Debug.Log($"Ты уронил предмет! {pointerDown} bebra bebra bebra");
    }

}
