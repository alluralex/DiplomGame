using Assets.Scripts;
using Assets.Scripts.UI;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopLogic : MonoBehaviour
{
    private List<ShopItem> ItemsFromShop;

    public UIDocument iDocument;



    void Start()
    {
        var root = iDocument.rootVisualElement;

        root.Query<Button>("ShopItem");

        ItemsFromShop = new List<ShopItem>();

        ItemsFromShop = (List<ShopItem>)root.Children();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
