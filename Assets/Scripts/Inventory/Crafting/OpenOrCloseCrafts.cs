using UnityEngine;

public class OpenOrCloseCrafts : MonoBehaviour
{
    [SerializeField] GameObject CraftMenu;

    [SerializeField] GameObject RecipeMenu;

    public void ClickCraft()
    {
        RecipeMenu.SetActive(false);
        CraftMenu.SetActive(true);
    }

    public void ClickRecipe()
    {
        RecipeMenu.SetActive(true);
        CraftMenu.SetActive(false);
    }

}
