using Assets.Scripts.Inventory.Upgrade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.InventoryUI
{
    public class ShowStatsCar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI TextDamage;
        [SerializeField] public TextMeshProUGUI TextSpeed;
        [SerializeField] private TextMeshProUGUI TextMoney;
        [SerializeField] private TextMeshProUGUI TextMultiplayedResource;

        [SerializeField] private UpgradeInfo Stats;

        private void Start()
        {
            Hero hero = FindFirstObjectByType<Hero>();
            hero.OnUpgradeInfoChanged += UpdateUI;
            UpdateUI();
        }

        private void UpdateUI()
        {
            TextDamage.text = Stats.damageMultiplayer.ToString();
            TextSpeed.text = Stats.speedMultiplayer.ToString();
            TextMoney.text = Stats.MoneyAdd.ToString();
            TextMultiplayedResource.text = Stats.ResourceMultiplayer.ToString();
        }
    }
}
