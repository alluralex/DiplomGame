using UnityEngine;
using UnityEngine.UI;

public class CellButton : MonoBehaviour
{
    private int x;
    private int y;
    private GridManager gridManager;
    private Image buttonImage;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void Init(int x, int y, GridManager manager)
    {
        this.x = x;
        this.y = y;
        this.gridManager = manager;
    }

    private void OnClick()
    {
        if (gridManager != null)
            gridManager.PurchaseCell(x, y);
    }

    public void SetColor(Color color)
    {
        if (buttonImage != null)
            buttonImage.color = color;
    }
}