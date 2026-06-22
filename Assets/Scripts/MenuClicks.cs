using Assets.Scripts.PlayerSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI.EscMenu
{
    public class MenuClicks : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;


        [SerializeField] private GameObject MainMenu;
        [SerializeField] private GameObject Compenduim;

        [SerializeField] private GameObject Settings;

        [SerializeField] private GameObject StatisticMenu;

        [SerializeField] private GameObject Menu;

        [SerializeField] private Canvas MenuCanvas;

        [SerializeField] private GameObject TutorialMenu;

        public void ReturnToGame()
        {
            MenuCanvas.enabled = false;
            Time.timeScale = 1.0f;
        }

       
        public void OpenSettings()
        {
            Settings.SetActive(true);
            MainMenu.SetActive(true);
            Menu.SetActive(false);
        }

        public void CloseSettings()
        {
            Menu.SetActive(true);
            MainMenu.SetActive(false);
            Settings.SetActive(false);
        }
        public void DoubleOpenSettings()
        {
            Settings.SetActive(true);
            Menu.SetActive(false);
        }

        public void DoubleCloseSettings()
        {
            Menu.SetActive(true);
            Settings.SetActive(false);
        }

        public void OpenStatistic()
        {
            StatisticMenu.SetActive(true);
            MainMenu.SetActive(true);
            Menu.SetActive(false);
        }
        public void OpenCompendium()
        {
            Compenduim.SetActive(true);
        }
        public void CloseCompendium()
        {
            Compenduim?.SetActive(false);
        }

        public void CloseStatistic()
        {
            Menu.SetActive(true);
            MainMenu.SetActive(false);
            StatisticMenu.SetActive(false);
        }

        public void GoToTheScene()
        {
            Statistic.Load();
            if (Statistic.TutorialCompleted == false)
            {
                TutorialMenu.SetActive(true);
            }
            else
            {
                StartGame();
            }
        }

        public void StartTutorial()
        {
            SceneManager.LoadScene("Tutorial");
        }
        public void StartGame()
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        public void CloseTheGame()
        {
            Application.Quit();
        }

        public void RestartTutorial()
        {
            Statistic.TutorialCompleted = false;
            Statistic.Save();
        }
    }
}
