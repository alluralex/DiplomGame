using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.Inventory
{
    public class InventorySlot
    {
        public Item Item;

        public bool IsEmpty => Item == null;

        public void Clear()
        {
            Item = null;
        }
    }
}
