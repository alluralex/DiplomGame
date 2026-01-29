using Assets.Scripts;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{
    [SerializeField] private UIDocument UIDocument;
    [SerializeField] private Hero hero;

    [SerializeField] public Item bebra;



    List<VisualElement> v;
    void Start()
    {
        VisualElement Grid = UIDocument.rootVisualElement.Q<VisualElement>("Grid");

        v = (List<VisualElement>)Grid.Children();
    }
    public void AddToInventoryUI(Item getItem)
    {
        for (int i = 0; i < 16; i++)
        {
            if (v[i].style.backgroundImage.value == null)
            {

                v[i].style.backgroundImage = getItem.Image;
                break;
            }
        }
    }

    public bool FullInventory()
    {
        for (int i = 0; i < 16; i++)
        {
            if (v[i].style.backgroundImage.value == null)
            {
                return true;
            }
        }
        return false;
    }
}
