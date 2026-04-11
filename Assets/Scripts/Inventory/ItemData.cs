using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    [CreateAssetMenu(menuName = "ItemData")]
    public class ItemData : ScriptableObject
    {
        public int ItemId;

        public string Name;
        public Sprite Image;
        public int buyPrice = 0;
        public int sellPrice;

        public ItemType type;
    }
}
