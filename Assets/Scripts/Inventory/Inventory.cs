using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        public List<Slot> items;

        public GameObject prefab;
        private void Start()
        {
            items = GetComponentsInChildren<Slot>().ToList();
        }

        public bool AddToInventory(ItemData data)
        {
            foreach (Slot slot in items)
            {
                if (slot.item == null)
                {
                    slot.item = data;
                    PrefabGet(slot);
                    slot.onItemChanged?.Invoke();
                    return true;
                }
            }
            Debug.Log("Инвентарь полон!");
            return false;
        }

        public void PrefabGet(Slot slot)
        {
            foreach (Transform child in slot.transform)
            {
                if (child == slot.item)
                    Destroy(child.gameObject);
                else break;
            }

            if (slot.item == null) return;

            GameObject obj = Instantiate(prefab, slot.transform);

            var image = obj.GetComponent<Image>();
            image.sprite = slot.item.Image;

            obj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }

        public bool HaveFreeSlot()
        {
            foreach(Slot slot in items)
            {
                if (slot.item == null) return true; 
            }
            return false;
        }

        public Slot[] GetSlots()
        {
            return GetComponentsInChildren<Slot>();
        }

        public bool HasItem(ItemData item)
        {
            foreach (Slot slot in items)
                if (slot.item == item) return true;
            return false;
        }
    }
}
