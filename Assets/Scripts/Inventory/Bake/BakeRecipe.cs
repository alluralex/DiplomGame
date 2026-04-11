using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory.Bake
{
    [CreateAssetMenu(menuName = "BakeRecipe")]
    public class BakeRecipe : ScriptableObject
    {
        public ItemData input;  
        public ItemData fuel;   
        public ItemData result; 
    }
}
