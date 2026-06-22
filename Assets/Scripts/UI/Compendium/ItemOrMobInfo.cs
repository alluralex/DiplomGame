using Assets.Scripts.Enemy;
using Assets.Scripts.Inventory;
using TMPro;
using UnityEngine;

public class ItemOrMobInfo : MonoBehaviour
{
    [Header("UI Text Fields")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI nameText;

    [Header("Data Sources")]
    [SerializeField] private TowerStats towerStats;   // для башни
    [SerializeField] private EnemyData enemyData;     // для врага

    private void Start()
    {
        UpdateUI();
    }

    // Обновление в редакторе при изменении полей
    private void OnValidate()
    {
        UpdateUI();
    }

    // Главный метод обновления UI
    public void UpdateUI()
    {
        if (towerStats != null)
        {
            SetTowerInfo(towerStats);
        }
        else if (enemyData != null)
        {
            SetEnemyInfo(enemyData);
        }
        else
        {
            ClearInfo();
        }
    }

    // Заполнение для башни
    public void SetTowerInfo(TowerStats stats)
    {
        if (stats == null)
        {
            ClearInfo();
            return;
        }
        nameText.text = stats.Title;
        healthText.text = stats.health.ToString();
        damageText.text = stats.damage.ToString();
        speedText.text = stats.fireRate.ToString(); // скорость атаки (выстрелов в секунду)
        // Если хотите показывать дальность, можно вместо fireRate вывести stats.range
    }

    // Заполнение для врага
    public void SetEnemyInfo(EnemyData data, EnemyMove move = null)
    {
        if (data == null)
        {
            ClearInfo();
            return;
        }
        // Используем встроенное поле name у ScriptableObject
        nameText.text = data.name;
        healthText.text = data.MaxHealth.ToString();
        damageText.text = data.Damage.ToString();
        // Скорость берём из EnemyMove, если он передан
        if (move != null)
            speedText.text = move.speed.ToString("F2");
        else
            speedText.text = ""; // или "N/A"
    }

    // Очистка всех полей
    private void ClearInfo()
    {
        nameText.text = "";
        healthText.text = "";
        damageText.text = "";
        speedText.text = "";
    }

    // Методы для установки данных извне
    public void SetTowerStats(TowerStats stats)
    {
        towerStats = stats;
        enemyData = null;
        UpdateUI();
    }

    public void SetEnemyStats(EnemyData data)
    {
        enemyData = data;
        towerStats = null;
        UpdateUI();
    }
}