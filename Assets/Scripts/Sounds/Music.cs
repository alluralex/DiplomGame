using Assets.Scripts.PlayerSettings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private List<AudioClip> musicList; 
    [SerializeField] private bool shuffle = true;

    [SerializeField] private AudioSource audioSource;
    private int currentIndex = 0;

    private void Start()
    {
        Settings.Load();

        Settings.OnMusicVolumeChanged += UpdateVolume;

        audioSource.volume = Settings.MusicValue;

        if (shuffle)
            ShuffleList();

        StartCoroutine(PlayMusic());
    }

    private IEnumerator PlayMusic()
    {
        while (true)
        {
            audioSource.clip = musicList[currentIndex];
            audioSource.Play();

            yield return new WaitForSeconds(audioSource.clip.length);

            currentIndex++;
            if (currentIndex >= musicList.Count)
            {
                if (shuffle)
                {
                    ShuffleList();
                    currentIndex = 0;
                }
                else
                {
                    currentIndex = 0;
                }
            }
        }
    }

    private void UpdateVolume(float newVolume)
    {
        audioSource.volume = newVolume;
    }

    private void OnDestroy()
    {
        Settings.OnMusicVolumeChanged -= UpdateVolume;
    }

    private void ShuffleList()
    {
        for (int i = 0; i < musicList.Count; i++)
        {
            int rand = Random.Range(i, musicList.Count);
            AudioClip temp = musicList[i];
            musicList[i] = musicList[rand];
            musicList[rand] = temp;
        }
    }
}