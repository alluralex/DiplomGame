using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.PlayerSettings
{
    public class StatisticUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI EnemiesDied;
        [SerializeField] private TextMeshProUGUI TotalAttempts;
        [SerializeField] private TextMeshProUGUI CompletedAttempts;
        [SerializeField] private TextMeshProUGUI MoneyEarned;
        [SerializeField] private TextMeshProUGUI ArtefactsBuy;
        [SerializeField] private TextMeshProUGUI FieldBuy;
        [SerializeField] private TextMeshProUGUI HealthGetCar;
        [SerializeField] private TextMeshProUGUI CompletedCrafts;

        private void Start()
        {
            Statistic.Load();

            EnemiesDied.text = Statistic.EnemiesDied.ToString();
            TotalAttempts.text = Statistic.TotalAttempts.ToString();
            CompletedAttempts.text = Statistic.CompletedAttempts.ToString();
            MoneyEarned.text = Statistic.MoneyEarned.ToString();
            ArtefactsBuy.text = Statistic.ArtefactsBuy.ToString();
            FieldBuy.text = Statistic.FieldBuy.ToString();
            HealthGetCar.text = Statistic.HealthGetCar.ToString();
            CompletedCrafts.text = Statistic.CompletedCrafts.ToString();
        }
    }
}
