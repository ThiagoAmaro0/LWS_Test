using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : Interactable
{
    private Crop _crop;

    private bool _watered;

    private int _days;
    private Sprite _holeSprite;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Water()
    {
        _watered = true;
        print("CHUA");
    }

    public void Plant(Crop crop)
    {
        print("Plantou");
        _crop = crop;
        UpdateSprite();
    }

    public void Grow()
    {
        if (_watered && _days < _crop.stages.Length - 1)
        {
            print("ZZZ");
            _watered = false;
            _days++;
            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        _spriteRenderer.sprite = _crop == null ? _holeSprite : _crop.stages[_days];
    }

    public override void OnInteract()
    {
        if (_days == _crop.stages.Length - 1)
        {
            print("Pronto");
        }
        else
        {
            print("Crescendo");
        }
    }
}
