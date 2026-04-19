using Assets.Scripts.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Slot : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    public ItemData item;

    private Inventory inventory;

    public Action onItemChanged;

    public bool IsResultSlot;

    private StatisticItem statisticItem;

    [SerializeField] private GameObject defaultIconPrefab;

    private void Awake()
    {
        inventory = GetComponentInParent<Inventory>();
        statisticItem = FindFirstObjectByType<StatisticItem>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsResultSlot) return;
        if (item == null) return;
        if (eventData.button != PointerEventData.InputButton.Left) return;

        if (statisticItem != null && item != null)
        {
            statisticItem.Image.sprite = item.Image;
            statisticItem.Title.text = item.Name;
            statisticItem.MoneyHero.text = item.sellPrice.ToString();
        }

        GrabByMouse.Item = item;
        GrabByMouse.FromSlot = this;

        item = null;

        UpdateVisual();
        onItemChanged?.Invoke();

        Debug.Log("Взяли предмет");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (statisticItem == null) return;
        statisticItem.Show(item, this);
    }

    public void OnDrag(PointerEventData eventData) { }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GrabByMouse.Item == null) return;

        if (GrabByMouse.Item != null)
        {
            Slot targetSlot = eventData.pointerEnter?.GetComponent<Slot>();

            if (targetSlot == null || targetSlot == GrabByMouse.FromSlot)
            {
                ReturnToSlot();
            }
        }
    }

    private void ReturnToSlot()
    {
        GrabByMouse.FromSlot.item = GrabByMouse.Item;

        GrabByMouse.FromSlot.UpdateVisual();
        GrabByMouse.FromSlot.onItemChanged?.Invoke();

        GrabByMouse.Item = null;
        GrabByMouse.FromSlot = null;

        Debug.Log("Предмет возвращен в исходный слот");
        onItemChanged?.Invoke();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (IsResultSlot)
        {
            ReturnToSlot();
            return;
        }
        if (GrabByMouse.Item == null) return;
        if (GrabByMouse.FromSlot == this) return;

        if (item == null)
        {
            item = GrabByMouse.Item;
            GrabByMouse.Item = null;
            GrabByMouse.FromSlot = null;
        }
        else
        {
            var temp = item;
            item = GrabByMouse.Item;
            GrabByMouse.FromSlot.item = temp;

            GrabByMouse.FromSlot.UpdateVisual();
            GrabByMouse.FromSlot.onItemChanged?.Invoke();

            GrabByMouse.Item = null;
            GrabByMouse.FromSlot = null;
        }

        UpdateVisual();
        onItemChanged?.Invoke();

        Debug.Log("Предмет положен в слот");
    }

    public void UpdateVisual()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
        if (item == null) return;

        GameObject prefabToUse = null;

        if (inventory != null && inventory.prefab != null)
            prefabToUse = inventory.prefab;
        else if (defaultIconPrefab != null)
            prefabToUse = defaultIconPrefab;
        else
        {
            Debug.LogError("Нет префаба иконки для слота!");
            return;
        }

        GameObject obj = Instantiate(prefabToUse, transform);
        Image img = obj.GetComponent<Image>();
        if (img != null)
            img.sprite = item.Image;
        else
            Debug.LogError("Префаб иконки не содержит Image");

        RectTransform rect = obj.GetComponent<RectTransform>();
        if (rect != null)
            rect.anchoredPosition = Vector2.zero;
    }
}
