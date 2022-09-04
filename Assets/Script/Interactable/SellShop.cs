using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SellShop : Interactable
{
    [SerializeField] private Item[] _sellItems;
    [SerializeField] private string[] _dialogMsgs;
    [SerializeField] private string _popupMsg;
    private static bool _intro;
    public override void OnInteract()
    {
        if (_stay)
        {
            if (_intro)
            {
                PopupManager.instance.ShowPopup(_popupMsg, Sell, true);
            }
            else
            {
                _intro = true;
                DialogSystem.instance.StartDialog(_dialogMsgs);
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
