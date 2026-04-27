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
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private Slot slotItem;
        [SerializeField] private ShopManager ShopManager;

        [SerializeField] private Hero MoneyHero;
        [SerializeField] private Inventory inventory;



        public TextMeshProUGUI CostItem;

        public void UpdateDisplay()
        {
            CostItem.text = slotItem.item.buyPrice.ToString();
            inventory.PrefabGet(slotItem);
        }

        private void Start()
        {
            UpdateDisplay(); 
            CostItem.text = slotItem.item.buyPrice.ToString();
            inventory.PrefabGet(slotItem);
        }

        public void OnClick()
        {
            if (MoneyHero.moneyHero >= slotItem.item.buyPrice)
            {
                MoneyHero.SpendMoney(slotItem.item.buyPrice);
                
                ShopManager.TakeResult(inventory, slotItem, slotItem.item.type, MoneyHero);

                CostItem.text = slotItem.item.buyPrice.ToString();
            }
            else
            {
                Debug.Log("Недостаточно шекелей дружок");
            }
        }

        
    }
}
