using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace Assets.Scripts.UI.GameEnd
{
    public class ShowResult : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] scriptsToDisable;
        [SerializeField] private HeroRotator heroRotator;

        [SerializeField] TextMeshProUGUI MoneyGet;
        [SerializeField] TextMeshProUGUI KilledMobs;
        [SerializeField] TextMeshProUGUI ArtefactsGet;
        [SerializeField] TextMeshProUGUI TerritoryBuy;
        [SerializeField] TextMeshProUGUI CraftsComplete;
        [SerializeField] TextMeshProUGUI BakedItems;

        [SerializeField] Canvas thisCanvas;

        [SerializeField] TextMeshProUGUI WinOrLose;

        private void OnEnable()
        {
            GlobalEvents.OnBossDefeated += ShowVictory;
            GlobalEvents.CarCrashed += ShowDefeat;
        }

        private void OnDisable()
        {
            GlobalEvents.OnBossDefeated -= ShowVictory;
            GlobalEvents.CarCrashed -= ShowDefeat;
        }

        private void ShowVictory()
        {
            WinOrLose.text = "ПОБЕДА";
            FillStats();
            DisableControl();
            thisCanvas.enabled = true;
        }

        private void ShowDefeat()
        {
            WinOrLose.text = "ПОРАЖЕНИЕ...";
            FillStats();
            DisableControl();
            thisCanvas.enabled = true;
        }

        private void FillStats()
        {
            MoneyGet.text = $"Получено денег: {StatisticAfterGame.MoneyEarned}";
            KilledMobs.text = $"Убито противников: {StatisticAfterGame.EnemiesKilled}";
            ArtefactsGet.text = $"Куплено артефактов: {StatisticAfterGame.ArtefactsBuy}";
            TerritoryBuy.text = $"Куплено земли: {StatisticAfterGame.TerritoryBuy}";
            CraftsComplete.text = $"Скрафчено вещей: {StatisticAfterGame.CraftsComplete}";
            BakedItems.text = $"Приготовлено в духовке: {StatisticAfterGame.BakedItems}";
        }

        private void DisableControl()
        {
            foreach (var script in scriptsToDisable)
                if (script != null) script.enabled = false;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }


}
