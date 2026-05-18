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

        [SerializeField] private GameObject TowerStatsObj;

        [SerializeField] private TextMeshProUGUI Damage;
        [SerializeField] private TextMeshProUGUI HP;
        [SerializeField] private TextMeshProUGUI Range;
        [SerializeField] private TextMeshProUGUI Speed;

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
            if (item.type == ItemType.Tower && item.TowerStats != null)
            {
                TowerStatsObj.SetActive(true);
                Damage.text = item.TowerStats.damage.ToString();
                HP.text = item.TowerStats.health.ToString();
                Range.text = item.TowerStats.range.ToString();
                Speed.text = item.TowerStats.fireRate.ToString();
            }
            else
            {
                TowerStatsObj.SetActive(false);
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
            if (CurrentItem == null || CurrentSlot == null) return;

            if (GrabByMouse.Item == CurrentItem && GrabByMouse.FromSlot == CurrentSlot)
            {
                GrabByMouse.Item = null;
                GrabByMouse.FromSlot = null;
            }

            heroMoney.GetMoney(CurrentItem.sellPrice);
            CurrentSlot.item = null;
            CurrentSlot.UpdateVisual();
            CurrentSlot.onItemChanged?.Invoke();

            Hide();
        }
    }
}
