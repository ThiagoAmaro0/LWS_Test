using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SellShop : Interactable
{
    [SerializeField] private Item[] _sellItems;
    private static bool _intro;
    public override void OnInteract()
    {
        if (_stay)
        {
            if (_intro)
            {
                PopupManager.instance.ShowPopup("Do you want to sell all your crops?", Sell, true);
            }
            else
            {
                _intro = true;
                DialogSystem.instance.StartDialog(new string[] { "Hi, i'm the crop buyer", "I love Tomatoes and potatoes, o would buy all the potatoes if i could" });
            }
        }
    }

    private void Sell()
    {
        foreach (Item item in PlayerInventory.instance.GetInventory())
        {
            if (_sellItems.Contains(item))
            {
                PlayerInventory.instance.AddMoney(item.value);
                PlayerInventory.instance.DiscardItem(item);
            }
        };
    }
}
