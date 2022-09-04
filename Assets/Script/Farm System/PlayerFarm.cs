using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerFarm : MonoBehaviour
{
    [SerializeField] private GameObject _harvestPrefab;
    [SerializeField] private Crop _potato;
    [SerializeField] private Crop _Tomato;
    private Tool _index;

    public static PlayerFarm instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void OnScroll(InputValue value)
    {
        int _scroll = (int)value.Get<Vector2>().normalized.y;
        _index = (Tool)Mathf.Clamp((int)_index + _scroll, 0, 3);

    }

    public void OnUse()
    {
        if (Time.timeScale == 0 || SceneManager.GetActiveScene().name != "Farm")
            return;
        Vector2 pos = transform.position + transform.right;
        var mouse = Mouse.current;
        if (mouse != null)
        {
            pos = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
            pos = new Vector2(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y)) + Vector2.one / 2;
            if (Vector2.Distance(transform.position, pos) > 5)
                return;
        }

        Collider2D result = Physics2D.OverlapBox(pos, new Vector2(0.5f, 0.5f), 0);
        switch (_index)
        {
            case Tool.Hoe:
                if (!result)
                    Instantiate(_harvestPrefab, pos, Quaternion.identity);
                else if (result.TryGetComponent<Harvest>(out Harvest _harvest))
                {
                    Destroy(_harvest.gameObject);
                }
                break;
            case Tool.WaterCan:
                if (result)
                    if (result.TryGetComponent<Harvest>(out Harvest _harvest))
                    {
                        _harvest.Water();
                    }
                break;
            case Tool.Potato:
                if (result)
                    if (result.TryGetComponent<Harvest>(out Harvest _harvest))
                    {
                        _harvest.Plant(_potato);
                    }
                break;
            case Tool.Tomato:
                if (result)
                    if (result.TryGetComponent<Harvest>(out Harvest _harvest))
                    {
                        _harvest.Plant(_Tomato);
                    }
                break;
        }

    }
    private enum Tool
    {
        Hoe, WaterCan, Potato, Tomato
    }

    public int GetIndex()
    {
        return (int)_index;
    }
}
