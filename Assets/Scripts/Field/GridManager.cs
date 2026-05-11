using Assets.Scripts.Field;
using Assets.Scripts.PlayerSettings;
using Assets.Scripts.UI.GameEnd;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GridCell[,] grid;
    [SerializeField] private Hero hero;       
    [SerializeField] public GridUI gridUI;   

    private int width = 7;
    private int height = 7;

    private int selectedX = -1;
    private int selectedY = -1;

    public int cellCost = 30;

    public int moneyadd = 5;
    private void Start()
    {
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        grid = new GridCell[width, height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject worldObj = GameObject.Find($"Field({x};{y})");
                grid[x, y] = new GridCell
                {
                    X = x,
                    Y = y,
                    State = CellState.Locked,
                    WorldObject = worldObj
                };
            }
        }
        grid[3, 3].State = CellState.Purchased;
        UpdateAvailableCells();
        gridUI.UpdateAllButtons();
    }

    public void SelectCell(int x, int y)
    {
        var cell = grid[x, y];
        if (cell.State == CellState.Available)
        {
            selectedX = x;
            selectedY = y;
            Debug.Log($"Выбрана клетка {x}:{y}");
        }
        else
        {
            selectedX = -1;
            selectedY = -1;
            Debug.Log($"Клетка {x}:{y} недоступна, выбор сброшен");
        }
    }

    public void BuySelectedCell()
    {
        if (selectedX == -1 || selectedY == -1)
        {
            Debug.Log("Сначала выберите доступную клетку");
            return;
        }

        var cell = grid[selectedX, selectedY];
        if (cell.State != CellState.Available)
        {
            Debug.Log("Выбранная клетка больше недоступна");
            selectedX = -1;
            selectedY = -1;
            return;
        }

        PurchaseCell(selectedX, selectedY);
    }
    public CellState GetCellState(int x, int y)
    {
        if (grid == null || x < 0 || x >= width || y < 0 || y >= height)
            return CellState.Locked;
        return grid[x, y].State;
    }

    public void PurchaseCell(int x, int y)
    {
        var cell = grid[x, y];

        if (cell.State == CellState.Purchased)
        {
            Debug.Log("Клетка уже куплена");
            return;
        }

        if (!HasPurchasedNeighbour(x, y))
        {
            Debug.Log("Нет соседней купленной клетки");
            return;
        }

        if (hero.moneyHero < cellCost)
        {
            Debug.Log("Не хватает денег");
            return;
        }

        hero.SpendMoney(cellCost);
        StatisticAfterGame.TerritoryBuy++;
        Statistic.FieldBuy++;
        Statistic.Save();
        cellCost += moneyadd;
        gridUI.CostZone.text = cellCost.ToString();
        cell.State = CellState.Purchased;

        RemoveWalls(cell);
        SpawnPortal(cell);

        UpdateAvailableCells();

        gridUI.UpdateAllButtons();

        Debug.Log($"Куплена клетка {x}:{y}");
    }

    private void RemoveWalls(GridCell cell)
    {
        if (cell.WorldObject == null) return;
        Transform walls = cell.WorldObject.transform.Find("Walls");
        if (walls != null)
            Destroy(walls.gameObject);
    }

    private void SpawnPortal(GridCell cell)
    {
        if (cell.WorldObject == null) return;
        Transform floor = cell.WorldObject.transform.Find("Floor");
        if (floor == null) return;

        Renderer renderer = floor.GetComponent<Renderer>();
        if (renderer == null) return;
        Bounds bounds = renderer.bounds;
        float padding = 1.5f;
        float x = Random.Range(bounds.min.x + padding, bounds.max.x - padding);
        float z = Random.Range(bounds.min.z + padding, bounds.max.z - padding);
        Vector3 pos = new Vector3(x, bounds.center.y + 0.5f, z);
        GameObject portalPrefab = GameObject.FindGameObjectWithTag("PortTag");
        float rot = Random.Range(0, 360);
        Instantiate(portalPrefab, pos, Quaternion.Euler(0, rot, 0), cell.WorldObject.transform);
    }

    private void UpdateAvailableCells()
    {
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                if (grid[x, y].State != CellState.Purchased)
                    grid[x, y].State = CellState.Locked;

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                if (grid[x, y].State != CellState.Purchased && HasPurchasedNeighbour(x, y))
                    grid[x, y].State = CellState.Available;
    }

    private bool HasPurchasedNeighbour(int x, int y)
    {
        Vector2Int[] dirs = new Vector2Int[]
        {
                new Vector2Int(1,0),
                new Vector2Int(-1,0),
                new Vector2Int(0,1),
                new Vector2Int(0,-1)
        };
        foreach (var dir in dirs)
        {
            int nx = x + dir.x;
            int ny = y + dir.y;
            if (nx >= 0 && nx < width && ny >= 0 && ny < height)
                if (grid[nx, ny].State == CellState.Purchased)
                    return true;
        }
        return false;
    }
}