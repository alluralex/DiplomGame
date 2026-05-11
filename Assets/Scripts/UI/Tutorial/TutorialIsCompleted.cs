using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI.Tutorial
{
    public class TutorialIsCompleted : MonoBehaviour
    {
        [SerializeField] private string sceneTutorial;

        [SerializeField] private string sceneGame;


        public void GoToTheTutorial()
        {
            SceneManager.LoadScene(sceneTutorial);
        }
        public void GoToTheGame()
        {
            SceneManager.LoadScene(sceneGame);
        }
        public void CloseThisWindow()
        {
            this.gameObject.SetActive(false);
        }
    }
}
