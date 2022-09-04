using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public int value;
    public Sprite sprite;
    public Sprite icon;

    public ItemType type;

    public enum ItemType { hat, shirt, pants, shoes, haircut, crop }
}
