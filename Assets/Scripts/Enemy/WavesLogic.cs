using Assets.Scripts.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


namespace Assets.Scripts
{
    public class WavesLogic : MonoBehaviour
    {
        public float waveDuration = 150f; // длительность волны (сек)

        public int MaxWave = 5; // максимальное количество ходов
        
        private float currentTime;

        private int currentWave = 0;

        private TypeAspect aspect;

        [SerializeField]private TextMeshProUGUI timerLabel;

        [SerializeField]private TextMeshProUGUI labelWave;

        [SerializeField]private TextMeshProUGUI labelWaveMax;

        private void Start()
        {

            labelWaveMax.text = MaxWave.ToString();

            timerLabel.text = waveDuration.ToString();

            labelWave.text = currentWave.ToString();

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

            int randomIndex = UnityEngine.Random.Range(0, 3);
            aspect = randomIndex switch
            {
                0 => TypeAspect.Lighting,
                1 => TypeAspect.Magic,
                2 => TypeAspect.Physics,
                _ => TypeAspect.Lighting
            };

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
