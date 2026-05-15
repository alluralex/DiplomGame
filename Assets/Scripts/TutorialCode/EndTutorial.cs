using Assets.Scripts.PlayerSettings;
using UnityEngine;

public class EndTutorial : MonoBehaviour
{
    public void Onclick()
    {
        Statistic.TutorialCompleted = true;
        Statistic.Save();
    }
}
