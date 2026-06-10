using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Inventory.Shop
{
    public class AdminPanel : MonoBehaviour
    {
        [SerializeField] private Slot slotItem;

        [SerializeField] private Inventory inventory;
        [SerializeField] private Inventory inventoryToGo;

        [SerializeField] private Hero Hero;

        [SerializeField] private ShopManager ShopManager;
        public void UpdateDisplay()
        {
            inventory.PrefabGet(slotItem);
        }

        private void Start()
        {
            UpdateDisplay();
            inventory.PrefabGet(slotItem);
        }

        public void OnClick()
        {
            ShopManager.TakeAdminItem(inventory, inventoryToGo, slotItem, slotItem.item.type, Hero);
        }
    }
}
