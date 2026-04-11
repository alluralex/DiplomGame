using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    [CreateAssetMenu(menuName = "CraftRecipe")]
    public class CraftRecipe : ScriptableObject
    {
        public ItemData[] pattern = new ItemData[9];
        public ItemData result;
    }
}
