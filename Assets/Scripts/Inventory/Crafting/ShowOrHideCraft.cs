using UnityEngine;
using UnityEngine.EventSystems;

public class ShowOrHideCraft : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject WindowForCraft;

    private void Start()
    {
        WindowForCraft.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        WindowForCraft.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        WindowForCraft.SetActive(false);
    }
}