using Assets.Scripts.Inventory;
using UnityEngine;

public class CraftTakeButton : MonoBehaviour
{
    [SerializeField] private CraftManager craftManager;
    [SerializeField] private Inventory inventory;


    public void OnClick()
    {
        craftManager.TakeResult(inventory);
    }

    public void OpenCrafts()
    {

    }
}