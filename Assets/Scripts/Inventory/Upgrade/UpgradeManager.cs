using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory.Upgrade
{
    public class UpgradeManager : MonoBehaviour
    {
        [SerializeField] private Slot slotUpgrade;
        [SerializeField] private Button buttonForUpgrade;
        [SerializeField] private DriveBox Car;
        [SerializeField] private UpgradeInfo upgradeInfo;

        

        public void UpgradeCar()
        {
            if (slotUpgrade.item == null) Debug.Log("Предмет помести");
            else
                switch (slotUpgrade.item.ItemId)
                {
                    case 4:
                        Car.AddHealth(5);
                        Debug.Log($"{Car.CurrentHealth}");
                        break;
                    case 6: 
                        upgradeInfo.damageMultiplayer += 0.05f;
                        break;
                    default:
                        Debug.Log($"При помощи такого предмета нельзя улучшить: {slotUpgrade.item.Name}");
                        return;

                }
            slotUpgrade.item = null;
            slotUpgrade.UpdateVisual();


        }

    }
}
