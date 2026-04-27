using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameEndHandler : MonoBehaviour
    {
        [SerializeField] private Canvas victoryPanel;

        private void OnEnable()
        {
            GlobalEvents.OnBossDefeated += ShowVictory;
        }
        private void OnDisable()
        {
            GlobalEvents.OnBossDefeated -= ShowVictory;
        }

        private void ShowVictory()
        {
            if (victoryPanel != null) 
            {
                victoryPanel.enabled = true;
                Debug.Log("Босс был убит, халявная победка");
            }
            Time.timeScale = 0f;
        }
    }
}
