using Assets.Scripts.PlayerSettings;
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
        [SerializeField] private TextMeshProUGUI Description;

        private Hero heroThis;

        public void Start()
        {
            heroThis = FindFirstObjectByType<Hero>();
            if (slotUpgrade != null)
            {
                slotUpgrade.onItemChanged += UpdateDescription;
                UpdateDescription(); // обновить при старте (если предмет уже лежит)
            }
        }

        private void UpdateDescription()
        {
            if (slotUpgrade.item == null)
            {
                Description.text = "Положите предмет для улучшения";
                return;
            }

            switch (slotUpgrade.item.ItemId)
            {
                case 0:
                    Description.text = "Увеличивает здоровье базы на 1";
                    break;
                case 1:
                    Description.text = "Увеличивает здоровье базы на 1";
                    break;
                case 2:
                    Description.text = "Увеличивает здоровье базы на 2";
                    break;
                case 3:
                    Description.text = "Увеличивает урон по нужному типу врага на 1%";
                    break;
                case 4:
                    Description.text = "Увеличивает здоровье базы на 5";
                    break;
                case 100:
                    Description.text = "Увеличивает урон по нужному типу врага на 5%";
                    break;
                case 101:
                    Description.text = "Увеличивает скорость игрока на 5%";
                    break;
                case 102:
                    Description.text = "Увеличивает здоровье базы на 25";
                    break;
                case 200:
                    Description.text = "Увеличивает здоровье базы на 10";
                    break;
                case 201:
                    Description.text = "Увеличивает здоровье базы на 10";
                    break;
                default:
                    Description.text = "С таким объектом нет улучшения!";
                    break;
            }
        }

        public void UpgradeCar()
        {
            if (slotUpgrade.item == null)
            {
                Debug.Log("Предмет не положен");
                Description.text = "Не вижу объект";
                return;
            }

            switch (slotUpgrade.item.ItemId)
            {
                case 0:
                    Car.AddHealth(1);
                    Statistic.HealthGetCar++;
                    Statistic.Save();
                    Description.text = null;
                    break;
                case 1:
                    Car.AddHealth(1);
                    Statistic.HealthGetCar++;
                    Statistic.Save();
                    Description.text = null;
                    break;
                case 2:
                    Car.AddHealth(2);
                    Statistic.HealthGetCar++;
                    Statistic.Save();
                    Description.text = null;
                    break;
                case 3:
                    upgradeInfo.damageMultiplayer += 0.01f;
                    Description.text = null;
                    break;
                case 4:
                    Car.AddHealth(5);
                    Statistic.HealthGetCar++;
                    Statistic.Save();
                    Description.text = null;
                    break;
                case 100:
                    upgradeInfo.damageMultiplayer += 0.05f;
                    Description.text = null;
                    break;
                case 101:
                    upgradeInfo.speedMultiplayer += 0.05f;
                    Description.text = null;
                    break;
                case 102:
                    Car.AddHealth(25);
                    Statistic.HealthGetCar++;
                    Statistic.Save();
                    Description.text = null;
                    break;
                case 200:
                    Car.AddHealth(10);
                    Statistic.HealthGetCar++;
                    Statistic.Save();
                    Description.text = null;
                    break;
                case 201:
                    Car.AddHealth(10);
                    Statistic.HealthGetCar++;
                    Statistic.Save();
                    Description.text = null;
                    break;
                default:
                    Debug.Log($"При помощи такого предмета нельзя улучшить: {slotUpgrade.item.Name}");
                    Description.text = "С таким объектом нет улучшения!";
                    return;
            }

            slotUpgrade.item = null;
            slotUpgrade.UpdateVisual();
            heroThis.InvokeUpgradeInfoChanged();
        }
    }
}