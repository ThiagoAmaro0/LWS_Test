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
            PopupManager.instance.ShowPopup($"Do you want buy {_item.itemName} for ${_item.value}?", Buy,
            PlayerInventory.instance.GetMoney() >= _item.value && !PlayerInventory.instance.GetInventory().Contains(_item));
        }
    }

    public void Buy()
    {
        PlayerInventory.instance.AddMoney(-_item.value);

        switch (_item.type)
        {
            case Item.ItemType.hat:
                PlayerInventory.instance.AddItem(_item);
                break;
            case Item.ItemType.haircut:
                PlayerInventory.instance.AddItem(_item);
                break;
            case Item.ItemType.shirt:
                PlayerInventory.instance.AddItem(_item);
                break;
            case Item.ItemType.pants:
                PlayerInventory.instance.AddItem(_item);
                break;
            case Item.ItemType.shoes:
                PlayerInventory.instance.AddItem(_item);
                break;
            default:
                break;
        }
    }
}
