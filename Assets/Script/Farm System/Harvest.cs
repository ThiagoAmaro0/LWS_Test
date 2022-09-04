using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : Interactable
{
    [SerializeField] private Sprite _holeSprite;
    private Crop _crop;

    private bool _watered;

    private int _days;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        House.nextDay += Grow;
        ChangeMap.changeSceneAction += Hide;
    }

    private void OnDisable()
    {
        House.nextDay -= Grow;
        ChangeMap.changeSceneAction -= Hide;
    }

    private void Hide(string scene)
    {
        _spriteRenderer.enabled = scene == "Farm";
    }

    public void Water()
    {
        _watered = true;
        _spriteRenderer.color = new Color(0, 1, 1);
    }

    public void Plant(Crop crop)
    {
        if (_crop == null)
        {
            _crop = crop;
            UpdateSprite();
        }
    }

    public void Grow()
    {
        if (_watered && _days < _crop.stages.Length - 1)
        {
            _days++;
            UpdateSprite();
        }
        _watered = false;
        _spriteRenderer.color = new Color(1, 1, 1);
    }

    private void UpdateSprite()
    {
        _spriteRenderer.sprite = _crop == null ? _holeSprite : _crop.stages[_days];
    }

    public override void OnInteract()
    {

        if (_crop != null && _stay)
            if (_days == _crop.stages.Length - 1)
            {
                bool haveSpace = PlayerInventory.instance.AddItem(_crop.cropItem);
                if (haveSpace)
                    Destroy(gameObject);
            }
            else
            {
                DialogSystem.instance.StartDialog(new string[] { $"Will be ready to harvest in {_crop.stages.Length - _days - 1} days" });
            }
    }
}
