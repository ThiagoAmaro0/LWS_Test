using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Item _hat;
    [SerializeField] private Item _shirt;
    [SerializeField] private Item _pants;
    [SerializeField] private Item _shoes;
    [SerializeField] private Item _hair;
    [SerializeField] private Item teste;
    private List<Item> _inventory;
    private int _money;

    public Action updateOutfitAction;
    public static PlayerInventory instance;
    private void Awake()
    {
        if (instance == null)
        {
            _inventory = new List<Item>();
            _inventory.Add(_shirt);
            _inventory.Add(_pants);
            _inventory.Add(_shoes);
            _inventory.Add(teste);

            instance = this;
        }
    }
    public Item[] GetInventory()
    {
        return _inventory.ToArray();
    }

    public bool IsEquiped(Item item)
    {
        if (_hat == item || _shirt == item || _pants == item || _shoes == item)
            return true;
        return false;
    }

    public Item GetHat()
    {
        return _hat;
    }
    public Item GetShirt()
    {
        return _shirt;
    }
    public Item GetPants()
    {
        return _pants;
    }
    public Item GetShoes()
    {
        return _shoes;
    }
    public Item GetHair()
    {
        return _hair;
    }

    public void SetHat(Item item)
    {
        _hat = item;
        updateOutfitAction?.Invoke();
    }
    public void SetShirt(Item item)
    {
        _shirt = item;
        updateOutfitAction?.Invoke();
    }
    public void SetPants(Item item)
    {
        _pants = item;
        updateOutfitAction?.Invoke();
    }
    public void SetShoes(Item item)
    {
        _shoes = item;
        updateOutfitAction?.Invoke();
    }
    public void SetHair(Item item)
    {
        _hair = item;
        updateOutfitAction?.Invoke();
    }

    public void DiscardItem(Item item)
    {
        _inventory.Remove(item);
    }

}
