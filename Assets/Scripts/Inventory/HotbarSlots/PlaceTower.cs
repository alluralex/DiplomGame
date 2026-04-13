using Assets.Scripts;
using Assets.Scripts.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerPlacer : MonoBehaviour
{
    [SerializeField] private Hotbar hotbar;
    [SerializeField] private Transform playerTransform; 
    [SerializeField] private float placeDistance = 0.66f;  

    public void OnPlaceTower(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        ItemData item = hotbar.GetActiveItem();
        if (item == null)
        {
            Debug.Log("В активном слоте хотбара нет предмета");
            return;
        }

        if (item.type != ItemType.Tower)
        {
            Debug.Log($"Предмет {item.Name} не является башней");
            return;
        }

        Vector3 forward = playerTransform.forward;
        forward.Normalize();
        Vector3 spawnPos = playerTransform.position + forward * placeDistance;
        spawnPos.y = 0.5f;

        Instantiate(item.Tower, spawnPos, Quaternion.identity);

        hotbar.ConsumeActiveItem();
    }
}