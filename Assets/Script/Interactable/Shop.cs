using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : Interactable
{
    [SerializeField] private Item _item;
    public override void OnInteract()
    {
        if (_stay && Time.timeScale != 0)
        {
            PopupManager.instance.ShowPopup($"Do you want to buy {_item.itemName} for ${_item.value}?", Buy,
            PlayerInventory.instance.GetMoney() >= _item.value && !PlayerInventory.instance.GetInventory().Contains(_item));
        }
    }

    public void Buy()
    {
        bool haveSpace = false;
        if (_item.type != Item.ItemType.crop)
        {
            haveSpace = PlayerInventory.instance.AddItem(_item);
        }
        if (haveSpace)
            PlayerInventory.instance.AddMoney(-_item.value);
    }
}
