using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory.Bake
{
    public class BakeTakeButton : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private BakeManager bakeManager;
        public void Onclick()
        {
            bakeManager.TakeResult(inventory);
        }

        
    }
}
