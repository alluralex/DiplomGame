using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Waves
{
    public class TimerAndWaves : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI CurrentWave;
        [SerializeField] private TextMeshProUGUI TimeCurrent;

        [SerializeField] private WavesLogic wavesLogic;

        [SerializeField] private MonoBehaviour[] scriptsToDisable;

        private int selectedMaxWave = 5;
        private int selectedWaveDuration = 60;

        private void Start()
        {
            Time.timeScale = 0f;

            CurrentWave.text = 5.ToString();
            UpdateTimeUI();

            DisableControl();
        }

        public void UpWaveCurrent()
        {
            if (selectedMaxWave < 11)
                selectedMaxWave++;
            UpdateWaveUI();
        }

        public void DownWaveCurrent()
        {
            if (selectedMaxWave > 1)
                selectedMaxWave--;
            UpdateWaveUI();
        }

        public void UpTimeCurrent()
        {
            if (selectedWaveDuration < 90)
                selectedWaveDuration += 15;
            UpdateTimeUI();
        }

        public void DownTimeCurrent()
        {
            if (selectedWaveDuration > 15)
                selectedWaveDuration -= 15;
            UpdateTimeUI();
        }

        public void StartButton()
        {

            wavesLogic.SetWaveParameters(selectedMaxWave, selectedWaveDuration);
            wavesLogic.StartGame();



            gameObject.SetActive(false);

            foreach (var script in scriptsToDisable)
                if (script != null) script.enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1f;
        }

        private void UpdateWaveUI()
        {
            CurrentWave.text = selectedMaxWave.ToString();
        }

        private void UpdateTimeUI()
        {
            int minutes = selectedWaveDuration / 60;
            int seconds = selectedWaveDuration % 60;
            TimeCurrent.text = $"{minutes:00}:{seconds:00}";
        }

        private void DisableControl()
        {
            foreach (var script in scriptsToDisable)
                if (script != null) script.enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
