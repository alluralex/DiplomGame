using Assets.Scripts.PlayerSettings;
using UnityEngine;

public class ClickPlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource clickOn;

    public void ClickButton()
    {
        Settings.Load();

        clickOn.volume = Settings.SoundValue;

        clickOn.Play();
    }
}
