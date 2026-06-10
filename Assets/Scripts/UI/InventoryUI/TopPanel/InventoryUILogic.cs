using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.UI.InventoryUI
{
    public class InventoryUILogic : MonoBehaviour
    {

        public Canvas UICanvas;

        public Canvas InventoryCanvas;

        public Canvas EscapeCanvas;

        public HeroRotator heroRotator;

        public Hero heroBlock;

        [SerializeField] private GameObject InventoryButton;
        [SerializeField] private GameObject CraftButton;
        [SerializeField] private GameObject BakeButton;
        [SerializeField] private GameObject UpgradeButton;
        [SerializeField] private GameObject CompassButton;
        [SerializeField] private GameObject ShopButton;
        [SerializeField] private GameObject AdminButton;

        public void OpenClose(InputAction.CallbackContext button)
        {

            if (InventoryCanvas.enabled == false && EscapeCanvas.enabled == true)
            {
                return;
            }
            else if(InventoryCanvas.enabled == false)
            {
                heroRotator.CursorUnblock();
                UICanvas.enabled = false;
                InventoryCanvas.enabled = true;
                heroBlock.InCar = false;
            }
            else
            {
                heroRotator.CursosBlock();
                UICanvas.enabled = true;
                InventoryCanvas.enabled = false;
                heroBlock.InCar = true;
            }
        }

        public void OpenMenu(InputAction.CallbackContext button)
        {
            if (EscapeCanvas.enabled == false && InventoryCanvas.enabled == true)
            {
                return;
            }
            else if (EscapeCanvas.enabled == false)
            {
                heroRotator.CursorUnblock();
                UICanvas.enabled = true;
                InventoryCanvas.enabled = false;
                EscapeCanvas.enabled = true;
                Time.timeScale = 0f;
            }
            else
            {
                heroRotator.CursosBlock();
                UICanvas.enabled = true;
                InventoryCanvas.enabled = false;
                EscapeCanvas.enabled = false;
                Time.timeScale = 1f;
            }
        }
        public void ShowWindowByIndex(int index)
        {
            InventoryButton.SetActive(false);
            CraftButton.SetActive(false);
            BakeButton.SetActive(false);
            UpgradeButton.SetActive(false);
            CompassButton.SetActive(false);
            ShopButton.SetActive(false);
            AdminButton.SetActive(false);

            switch (index)
            {
                case 0: InventoryButton.SetActive(true); break;
                case 1: CraftButton.SetActive(true); break;
                case 2: BakeButton.SetActive(true); break;
                case 3: UpgradeButton.SetActive(true); break;
                case 4: CompassButton.SetActive(true); break;
                case 5: ShopButton.SetActive(true); break;
                case 6: AdminButton.SetActive(true); break;
            }
        }
    }
}
