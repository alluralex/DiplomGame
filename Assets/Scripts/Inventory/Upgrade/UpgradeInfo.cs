using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory.Upgrade
{
    public class UpgradeInfo : MonoBehaviour
    {
        [Header("Множители")]
        public float damageMultiplayer = 1f;
        public float speedMultiplayer = 1f;
        public int MoneyAdd = 0;
        public int ResourceMultiplayer = 99;
    }
}
