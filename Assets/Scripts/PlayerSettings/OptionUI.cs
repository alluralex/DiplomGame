using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

namespace Assets.Scripts.PlayerSettings
{
    public class OptionUI : MonoBehaviour
    {
        [SerializeField] private Slider MasterVolumeSlider;
        [SerializeField] private Slider MusicVolumeSlider;
        [SerializeField] private Slider SoundVolumeSlider;
        [SerializeField] private Slider? MousePowerSlider;

        [SerializeField] private HeroRotator? HeroRotator;

        private void Start()
        {
            Settings.Load();


            MasterVolumeSlider.value = Settings.MasterValue;
            MusicVolumeSlider.value = Settings.MusicValue;
            SoundVolumeSlider.value = Settings.SoundValue;
            MousePowerSlider.value = Settings.MouseGetting;

            HeroRotator._speed = Settings.MouseGetting;

            MasterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
            MusicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
            SoundVolumeSlider.onValueChanged.AddListener(OnSoundVolumeChanged);
            MousePowerSlider.onValueChanged.AddListener(OnMousePowerChanged);
        }

        public void OnMasterVolumeChanged(float value)
        {
            Settings.MasterValue = value;
            Settings.Save();
        }

        public void OnMusicVolumeChanged(float value)
        {
            Settings.MusicValue = value;
            Settings.Save();
        }
        public void OnSoundVolumeChanged(float value)
        {
            Settings.SoundValue = value;
            Settings.Save();
        }
        public void OnMousePowerChanged(float value)
        {
            Settings.MouseGetting = value;
            HeroRotator._speed = value;
            Settings.Save();
        }
    }
}
