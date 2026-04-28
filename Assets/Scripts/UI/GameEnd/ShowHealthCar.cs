using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.UI.GameEnd
{
    public class ShowHealthCar : MonoBehaviour
    {
        public DriveBox driveBox;

        [SerializeField] TextMeshProUGUI CurrentHealth;

        private void OnEnable()
        {
            driveBox.OnHealthCnanged += UpdateHealthUI;
        }

        private void OnDisable()
        {
            driveBox.OnHealthCnanged -= UpdateHealthUI;
        }

        private void Start()
        {
            UpdateHealthUI(driveBox.CurrentHealth);
        }

        private void UpdateHealthUI(int newHealth)
        {
            CurrentHealth.text = newHealth.ToString();
        }
    }
}
