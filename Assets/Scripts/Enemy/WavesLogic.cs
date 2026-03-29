using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class WavesLogic : MonoBehaviour
    {
        public float waveDuration = 150f; // длительность волны (сек)

        public int MaxWave = 5; // максимальное количество ходов
        
        private float currentTime;

        private int currentWave = 0;

        private Label timerLabel;

        private Label labelWave;

        private Label labelWaveMax;

        private void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            timerLabel = root.Q<Label>("SecondsLeft");

            labelWave = root.Q<Label>("WaveLabelCurrent");

            labelWaveMax = root.Q<Label>("WaveLabelEnd");

            labelWaveMax.text = MaxWave.ToString();

            StartWave();
        }

        private void Update()
        {
            currentTime -= Time.deltaTime;
            if (currentWave != MaxWave)
            {

                if (currentTime <= 0 && currentWave != MaxWave)
                {
                    NextWave();
                }

                UpdateUI();
            }
            else 
            {
                timerLabel.text = "убей босса!";
            }

        }

        void StartWave()
        {
            currentTime = waveDuration;

            GlobalEvents.unityEvent.Invoke(currentWave);
        }

        void NextWave()
        {
            currentWave++;
            labelWave.text = currentWave.ToString();
            Debug.Log("Новая волна: " + currentWave);

            StartWave();
        }

        void UpdateUI()
        {
            int seconds = Mathf.CeilToInt(currentTime);

            int minutes = seconds / 60;
            int secs = seconds % 60;

            timerLabel.text = $"{minutes:00}:{secs:00}";
        }
    }
}
