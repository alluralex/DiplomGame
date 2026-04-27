using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI.EscMenu
{
    public class MenuClicks : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;

        [SerializeField] private GameObject Settings;

        [SerializeField] private GameObject Menu;

        [SerializeField] private Canvas MenuCanvas;
        public void ReturnToGame()
        {
            MenuCanvas.enabled = false;
        }

        public void OpenSettings()
        {
            Settings.SetActive(true);
            Menu.SetActive(false);
        }

        public void CloseSettings()
        {
            Menu.SetActive(true);
            Settings.SetActive(false);
        }

        public void GoToTheScene()
        {
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogWarning("Название сцены для загрузки не указано!");
            }
        }

        public void CloseTheGame()
        {
            Application.Quit();
        }

        public void OpenStatistic()
        {

        }
    }
}
