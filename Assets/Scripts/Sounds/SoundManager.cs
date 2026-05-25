using Assets.Scripts.PlayerSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Sounds
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        [SerializeField] private AudioSource _audioSource;

        public AudioClip TowerShot;
        public AudioClip BaseTakeDamage;
        public AudioClip TowerDestroy;

        private void Awake()
        {
            Instance = this;
            
        }

        public void PlaySound(AudioClip clip)
        {
            Settings.Load();

            _audioSource.volume = Settings.SoundValue;

            _audioSource.PlayOneShot(clip);
        }
    }
}
