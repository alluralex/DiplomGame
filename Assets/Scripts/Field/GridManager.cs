using Assets.Scripts.Field;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    public GridCell[,] grid;



    private int width = 7;
    private int height = 7;

    void Start()
    {
        InitializeGrid();
    }

    

    void InitializeGrid()
    {
        grid = new GridCell[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                grid[x, y] = new GridCell
                {
                    X = x,
                    Y = y,
                    State = CellState.Locked,
                    WorldObject = GameObject.Find($"Field({x};{y})")
                };
            }
        }

        grid[3, 3].State = CellState.Purchased;
        UpdateAvailableCells();
    }
    public void PurchaseCell(int x, int y)
    {
        var cell = grid[x, y];


        //hero.SpendMoney(3);
        cell.State = CellState.Purchased;


        RemoveWalls(cell);
        UpdateAvailableCells();
    }

    void RemoveWalls(GridCell cell)
    {
        var walls = cell.WorldObject.transform.Find("Walls");

        if (walls != null)
            Destroy(walls.gameObject);
    }

    void UpdateAvailableCells()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var cell = grid[x, y];

                if (cell.State == CellState.Purchased)
                    continue;

                if (HasPurchasedNeighbour(x, y))
                    cell.State = CellState.Locked;
            }
        }
    }

    bool HasPurchasedNeighbour(int x, int y)
    {
        Vector2Int[] directions =
        {
            new Vector2Int(1,0),
            new Vector2Int(-1,0),
            new Vector2Int(0,1),
            new Vector2Int(0,-1)
        };

        foreach (var dir in directions)
        {
            int nx = x + dir.x;
            int ny = y + dir.y;

            if (nx >= 0 && nx < width && ny >= 0 && ny < height)
            {
                if (grid[nx, ny].State == CellState.Purchased)
                    //Можно сделать перекрас в зелёный цвет
                    return true;
            }
        }

        return false;
    }
}
