using Assets.Scripts;
using Assets.Scripts.Field;
using System;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Cubes : MonoBehaviour
{
    public UIDocument iDocument;

    private GridCell[,] gridMy;

    [SerializeField] private GridManager gridManager;



    void Start()
    {
        var root = iDocument.rootVisualElement;



        var grid = root.Q<VisualElement>("GridMapContainer");

        for (int y = 0; y <= 6; y++)
        {
            for (int x = 0; x <= 6; x++)
            {
                string buttonName = $"X{x}Y{y}";

                var cell = gridManager.grid[x, y];
                var button = grid.Q<Button>(buttonName);

                cell.UIButton = button;
                int localX = x;
                int localY = y;

                button.clicked += () =>
                {
                    OnCellClicked(localX, localY, cell);
                    UpdateCellColor(cell);
                };
            }
        }
    }

    void OnCellClicked(int x, int y, GridCell cell)
    {
        Debug.Log($"Нажата клетка {x}:{y}");
        if (cell.State != CellState.Purchased)
        {
            gridManager.PurchaseCell(x, y);
        }
        else {
            Debug.Log("Ай блин, уже куплена клетка");

        }
    }

    private void UpdateCellColor(GridCell cell)
    {
        switch (cell.State)
        {

            case CellState.Locked:
                cell.UIButton.style.backgroundColor =
                    new StyleColor(new Color32(144, 37, 37, 255));
                return;

            case CellState.Purchased:
                cell.UIButton.style.backgroundColor =
                    new StyleColor(new Color32(64, 199, 202, 255));
                return;
        }
    }


}
