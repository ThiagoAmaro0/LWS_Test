using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "ScriptableObject/Crop")]
public class Crop : ScriptableObject
{
    public Item cropItem;

    public Sprite[] stages;
}
