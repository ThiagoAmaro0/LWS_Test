using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    [SerializeField] private Transform _inventoryPanel;
    [SerializeField] private GameObject _itemPanel;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descText;
    [SerializeField] private Button _discardButton;
    [SerializeField] private Button _equipButton;
    [SerializeField] private Image _hairImage;
    [SerializeField] private Image _hatImage;
    [SerializeField] private Image _shirtImage;
    [SerializeField] private Image _pantsImage;
    [SerializeField] private Image _shoesImage;

    private Item _item;

    private void Update()
    {
        UpdatePreview();
        Item[] _inventory = PlayerInventory.instance.GetInventory();
        for (int i = 0; i < _inventoryPanel.childCount; i++)
        {
            Image icon = _inventoryPanel.GetChild(i).GetChild(0).GetComponent<Image>();
            Image equipped = _inventoryPanel.GetChild(i).GetChild(1).GetComponent<Image>();
            Button btn = _inventoryPanel.GetChild(i).GetComponent<Button>();

            if (_inventory.Length > i)
            {
                btn.interactable = true;
                icon.enabled = true;
                icon.sprite = _inventory[i].sprite;
                equipped.enabled = PlayerInventory.instance.IsEquiped(_inventory[i]);
            }
            else
            {
                btn.interactable = false;
                icon.enabled = false;
                equipped.enabled = false;
            }
        }
    }

    public void UpdatePreview()
    {
        if (PlayerInventory.instance.GetHat() != null)
        {
            _hatImage.enabled = true;
            _hatImage.sprite = PlayerInventory.instance.GetHat().sprite;
        }
        else
            _hatImage.enabled = false;
        _hairImage.sprite = PlayerInventory.instance.GetHair().sprite;
        _shirtImage.sprite = PlayerInventory.instance.GetShirt().sprite;
        _pantsImage.sprite = PlayerInventory.instance.GetPants().sprite;
        _shoesImage.sprite = PlayerInventory.instance.GetShoes().sprite;
    }

    public void SelectItem()
    {
        int index = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
        _item = PlayerInventory.instance.GetInventory()[index];

        if (_item == null)
            return;

        _itemPanel.SetActive(true);
        _nameText.text = _item.itemName;
        _descText.text = _item.description;

        bool equipped = PlayerInventory.instance.IsEquiped(_item);
        _equipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
        _equipButton.interactable = !equipped;
        _discardButton.interactable = !equipped;
        if (_item.type == Item.ItemType.hat)
        {
            _equipButton.interactable = true;
            if (equipped)
            {
                _equipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unequip";
            }
            else
            {
                _equipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
            }
        }
    }

    public void EquipItem()
    {
        _equipButton.interactable = false;
        switch (_item.type)
        {
            case Item.ItemType.hat:
                _equipButton.interactable = true;
                if (PlayerInventory.instance.IsEquiped(_item))
                {
                    PlayerInventory.instance.SetHat(null);
                    _equipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
                    _discardButton.interactable = true;
                }
                else
                {
                    _equipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unequip";
                    PlayerInventory.instance.SetHat(_item);
                    _itemPanel.SetActive(false);
                }
                break;
            case Item.ItemType.shirt:
                _itemPanel.SetActive(false);
                PlayerInventory.instance.SetShirt(_item);
                break;
            case Item.ItemType.pants:
                _itemPanel.SetActive(false);
                PlayerInventory.instance.SetPants(_item);
                break;
            case Item.ItemType.shoes:
                _itemPanel.SetActive(false);
                PlayerInventory.instance.SetShoes(_item);
                break;
            default:
                break;
        }
    }

    public void DiscardItem()
    {
        PlayerInventory.instance.DiscardItem(_item);
        _itemPanel.SetActive(false);
    }

}
