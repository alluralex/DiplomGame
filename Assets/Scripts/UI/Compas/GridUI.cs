using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Field
{
    public class GridUI : MonoBehaviour
    {
        [SerializeField] private GameObject buttonPrefab;
        [SerializeField] private Transform parent;       
        [SerializeField] private GridManager gridManager;

        public TextMeshProUGUI CostZone;

        private int width = 7;
        private int height = 7;
        private CellButton[,] buttons;

        private void Start()
        {
            if (gridManager == null)
            {
                Debug.LogError("GridUI: gridManager not assigned!");
                return;
            }

            buttons = new CellButton[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    GameObject obj = Instantiate(buttonPrefab, parent);
                    CellButton btn = obj.GetComponent<CellButton>();
                    if (btn == null)
                    {
                        Debug.LogError("Button prefab missing CellButton component");
                        continue;
                    }
                    btn.Init(x, y, gridManager);
                    buttons[x, y] = btn;
                }
            }

            UpdateAllButtons();
        }

        public void UpdateButtonColor(int x, int y, CellState state)
        {
            if (buttons == null || x < 0 || x >= width || y < 0 || y >= height) return;
            CellButton btn = buttons[x, y];
            if (btn == null) return;

            Color color = state switch
            {
                CellState.Purchased => Color.green,
                CellState.Available => Color.yellow,
                CellState.Locked => Color.darkRed,
                _ => Color.hotPink
            };
            btn.SetColor(color);
        }

        public void UpdateAllButtons()
        {
            if (gridManager == null) return;
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    UpdateButtonColor(x, y, gridManager.GetCellState(x, y));
        }
    }
}