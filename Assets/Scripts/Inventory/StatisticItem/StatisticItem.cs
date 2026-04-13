using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory
{
    public class StatisticItem : MonoBehaviour
    {
        public TextMeshProUGUI MoneyHero;
        public Image Image;
        public TextMeshProUGUI Title;

        private ItemData CurrentItem;
        private Slot CurrentSlot;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void Show(ItemData item, Slot slot)
        {
            if (item == null)
            {
                Hide();
                return;
            }
            CurrentItem = item;
            CurrentSlot = slot;
            Image.sprite = item.Image;
            Title.text = item.Name;
            MoneyHero.text = item.sellPrice.ToString();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            CurrentItem = null;
            CurrentSlot = null;
            gameObject.SetActive(false);
        }

        public void SellItem(Hero heroMoney)
        {
            if (CurrentItem == null || CurrentSlot == null)
            {
                Debug.Log("Нет выбранного предмета для продажи");
                return;
            }

            heroMoney.GetMoney(CurrentItem.sellPrice);

            CurrentSlot.item = null;
            CurrentSlot.UpdateVisual();
            CurrentSlot.onItemChanged?.Invoke();

            Hide();
        }
    }
}
